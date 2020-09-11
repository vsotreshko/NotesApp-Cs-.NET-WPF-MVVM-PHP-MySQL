using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class WebServise
    {
        public HttpClient HttpClient { get; set; }

        public WebServise ()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://lolokol.000webhostapp.com/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> SignUp(string email, string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string> {
                    { "email", email },
                    { "username", username },
                    { "password", password }
                };

                string response = string.Empty;
                var encodedContent = new FormUrlEncodedContent(parameters);
                
                var result = await httpClient.PostAsync("https://lolokol.000webhostapp.com/signup.php", encodedContent);

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                return response;
            }
        }

        internal void DeleteNote()
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(string username, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var response = string.Empty;
                var result = await httpClient.GetAsync(string.Format("https://lolokol.000webhostapp.com/login.php?username={0}&password={1}", username, password));

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                return response;
            }
        }

        public async Task<string> DeleteNote(string username, string password, int note_id)
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string> {
                    { "note_id", note_id.ToString() },
                    { "username", username },
                    { "password", password }
                };

                string response = string.Empty;
                var encodedContent = new FormUrlEncodedContent(parameters);

                var result = await httpClient.PostAsync("https://lolokol.000webhostapp.com/deleteNote.php", encodedContent);

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                return response;
            }
        }

        public async Task<string> AddNote(string username, string password, string note_title, string note_text)
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string> {
                    { "note_title", note_title },
                    { "note_text", note_text },
                    { "username", username },
                    { "password", password }
                };

                string response = string.Empty;
                var encodedContent = new FormUrlEncodedContent(parameters);

                var result = await httpClient.PostAsync("https://lolokol.000webhostapp.com/addNote.php", encodedContent);

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                return response;
            }
        }

        public async Task<string> EditNote(string username, string password, int note_id, string note_title, string note_text)
        {
            using (var httpClient = new HttpClient())
            {
                var parameters = new Dictionary<string, string> {
                    { "note_id", note_id.ToString() },
                    { "note_title", note_title },
                    { "note_text", note_text },
                    { "username", username },
                    { "password", password }
                };

                string response = string.Empty;
                var encodedContent = new FormUrlEncodedContent(parameters);

                var result = await httpClient.PostAsync("https://lolokol.000webhostapp.com/editNote.php", encodedContent);

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                return response;
            }
        }
    }
}
