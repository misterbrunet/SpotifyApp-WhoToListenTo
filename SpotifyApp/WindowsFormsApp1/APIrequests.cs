using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WhoToListenTo
{
    public class APIrequests
    {
        #region Variables
        public event EventHandler<string> NewError;
        BasicItemSQL errorItem;
        #endregion

        #region Test Async Function
        /// <summary>
        /// Used only for early tests
        /// </summary>
        /// <returns></returns>
        public async Task<DataTest> LoadData()
        {
            string url = $"http://127.0.0.1:5000/data";

            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DataTest dt = await response.Content.ReadAsAsync<DataTest>();
                    return dt;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        #endregion

        #region Async Functions for Spotify Data
        /// <summary>
        /// Retrives JSON object with serialized data and translates it into a list. Raises error events if they occur.
        /// </summary>
        /// <param name="artist">name of the search Artist</param>
        /// <returns></returns>
        public async Task<List<Artist>> LoadDataArtist(string artist)
        {
            string url = $@"http://127.0.0.1:5000/artist/{artist}";
            List<Artist> list = new List<Artist>();

            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var dt = await response.Content.ReadAsStringAsync();
                    try
                    {
                        list = JsonConvert.DeserializeObject<List<Artist>>(dt);
                    }
                    catch //If something goes wrong e.i. cannot deserialize into List<Artist>
                    {
                        try
                        {
                            Artist a = new Artist();
                            a = JsonConvert.DeserializeObject<Artist>(dt);  //Add single Artist
                            list.Add(a);
                        }
                        catch
                        {
                            NewError?.Invoke(this, "errorArtist");
                        }                     
                    }
                    return list;
                }
                else
                {
                    NewError?.Invoke(this, "errorArtist");
                    return list;
                }
            }
        }
        /// <summary>
        /// Retrives JSON object with serialized data and deserializes it to a List of Songs with retrieved parameters.
        /// </summary>
        /// <param name="artist">name of the searched Artist</param>
        /// <param name="song">full name OR substring of a song which belongs to the Artist</param>
        /// <returns></returns>
        public async Task<List<Song>> LoadDataSong(string artist, string song)
        {
            string url = $@"http://127.0.0.1:5000/song/{artist}/{song}";

            List<Song> list = new List<Song>();
            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var dt = await response.Content.ReadAsStringAsync();
                    try
                    {
                        list = JsonConvert.DeserializeObject<List<Song>>(dt);
                    }
                    catch
                    {
                        try
                        {
                            Song s = new Song();
                            s = JsonConvert.DeserializeObject<Song>(dt);
                            list.Add(s);
                        }
                        catch
                        {
                            NewError?.Invoke(this, "errorSong");
                        }
                        
                    }                   
                    return list;
                }
                else
                {
                    NewError?.Invoke(this, response.ReasonPhrase);
                    return list;
                }
            }
        }
        #endregion

        #region Async Functions for BasicItemSQL 
        /// <summary>
        /// Retrives and deserializes JSON object containing all the objects in the SQL DB.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BasicItemSQL>> LoadDataBasicItemSQL()
        {
            string url = $@"http://127.0.0.1:5000/basicitemssql";

            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var dt = await response.Content.ReadAsStringAsync();
                    List<BasicItemSQL> list = new List<BasicItemSQL>();
                    try
                    {
                        list = JsonConvert.DeserializeObject<List<BasicItemSQL>>(dt);
                    }
                    catch
                    {   //If there's ony one item, the function might not behave as promised. That's why 
                        //In such situation one object will be passed to a safe variable.
                        try
                        {
                            BasicItemSQL oneItem = new BasicItemSQL();
                            oneItem = JsonConvert.DeserializeObject<BasicItemSQL>(dt);
                            list.Add(oneItem);
                        }                                            
                        catch
                        {
                            NewError?.Invoke(this, "There was a problem retrieving data from the API.");
                        }                           
                    }                 
                    return list;
                }
                else
                {   //It this gets thrown, then do something about it.
                    throw new Exception(response.ReasonPhrase); 
                }
            }
        }
        /// <summary>
        /// Retrives one JSON object with information if the procces went correctly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<BasicItemSQL> AddBasicItemSQL(string name, float number)
        {
            string url = $@"http://127.0.0.1:5000/basicitemssql/{name}/{number}";

            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                var dt = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BasicItemSQL>(dt);
                if (item.name == "error")
                {
                    NewError?.Invoke(this,"there was a problem adding an Item to the SQL");
                    return errorItem;
                }
                else return item;
            }
        }
        /// <summary>
        /// Retrives one JSON object with information if the procces went correctly.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<BasicItemSQL> DeleteBasicItemSQL(string name, float number)
        {
            string url = $@"http://127.0.0.1:5000/basicitemssql/delete/{name}/{number}";

            using (HttpResponseMessage response = await APIHandler.ApiClient.GetAsync(url))
            {
                var dt = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BasicItemSQL>(dt);
                if (item.name == "error")
                {
                    NewError?.Invoke(this, "there was a problem");
                    return errorItem;
                }
                else return item;
            }
        }
        #endregion

    }
}
