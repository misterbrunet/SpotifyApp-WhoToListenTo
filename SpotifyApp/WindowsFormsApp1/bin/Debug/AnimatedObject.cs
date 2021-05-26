using System;
using System.Drawing;

namespace WhoToListenTo
{
    /// <summary>
    /// Animated Object displays in one of the MainForm's panels. Meant to be a ball-shaped object.
    /// </summary>
    public class AnimatedObject
    {
        #region Variables
        public double X { get; set; }               //X Position on X-axis
        public double Y { get; set; }               //Y position on Y-axis
        public double V { get; set; }               //Speed of an animated object
        public string Direction { get; set; }       //Direction of an animated object
        public float BottomLevel { get; set; }      //Ground level which is maximum value in object trajectory
        public double V0 { get; set; }              //Additional value needed in math calqulations, which represents
                                                    //previous-frame speed
        Image img = Image.FromFile("spotify-logo.png"); //Image used in animation
        #endregion

        public AnimatedObject()
        {
            Y = 75;                 //Strating postion on Y-axis (remember it's reversed in C#)
            V = 45;                 //Initial speed
            V0 = 45;                //Initial adidtional speed
            Direction = "fall";     //Initial direction
        }

        #region Funtions
        /// <summary>
        /// Draws an image in currently coresponding frame.
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            var m = g.Transform;                        //Save the initial state of a 2D matrix
            g.TranslateTransform((float)X, (float)Y);   //These will change due to the calqulations
            g.ScaleTransform(0.1f, 0.1f);               //I need to resize an image.   
            PointF center = new Point();
            center.X = (-img.Width) / 2f;               //Need to obtain center of the image due to
            center.Y = (-img.Height) / 2f;              //correct way of displaying this image compared to original 2D matrix
            g.DrawImage(img, center);                   //Draw an Image in its new place with new cords.
            g.Transform = m;                            //Put changes together with the initial state of the 2D matrix
        }

        /////////////////////////////////////
        const double a = 40; //acceleration//
        const float oneFrameTime = 0.024f;///   Values used in math calqulations.
        /////////////////////////////////////

        /// <summary>
        /// Performs adequate calqulations for falling unless the image reaches BottomLevel limit. 
        /// </summary>
        public void ProperFall()
        {
            if (Y + 15 >= BottomLevel)      //It's the center of the image + its radius
            {
                Direction = "bounce";       //If the limit is reached, direction is changed
                V = -V;                     //with the same speed, but with different calqulations
            }
            else
            {
                V = V0 + a * oneFrameTime;  //Speed increases in nonlinear way
                V0 = V;                     //Pass the current Velocity to "last-frame-speed"
                Y = Y + V * oneFrameTime + a * oneFrameTime * oneFrameTime;
                //Y cordinate gets a new value according to Image's instantaneous speed
            }
        }
        /// <summary>
        /// Performs adequate calqulations for movement up after bouncing straight up.
        /// </summary>
        public void Bounce()
        {
            //If center of the image + 20 pixels reaches top of the panel OR Velocity is greater than 0 AND Velocity is lecc than 0.8
            //The direction will change. Range from 0 to 0.8 eliminates the problem of too small results of the math equations
            //so that the image doesn't magically go under the panel or escape into space.
            if (Y - 20 < 0 || V >= 0 && V < 0.8)
            {
                Direction = "fall";
                V = a * oneFrameTime;
                V0 = a * oneFrameTime;
            }
            else
            {
               if (V0 >= 0) V0 = -V0 * 0.85;
               V = V0 + a * oneFrameTime; 
               V0 = V;
                Y = Y + V * oneFrameTime - a * oneFrameTime * oneFrameTime;
            }
        }
        #endregion
    }
}
