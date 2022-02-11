using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace Fetch_Data_From_Json
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string LoadJson()
        {
            string output ="";
            using (StreamReader r = new StreamReader("users.json"))
            {
                
                string json = r.ReadToEnd();
                List<Posts> items = JsonConvert.DeserializeObject<List<Posts>>(json);
                foreach (Posts post in items)
                {
                    int postId = post.postId;
                    int id = post.id;
                    string email = post.email;
                    string name = post.name;
                    string body = post.body;
                    output += "User ID : " + postId + "\r\n";
                    output += "ID : " + id + "\r\n";
                    output += "Email : " + email + "\r\n";
                    output += "Name : " + name + "\r\n";
                    output += "Body : " + body + "\r\n";
                }
            }
            return output;
        }
        public class Posts
        {
            public int postId;
            public int id;
            public string name;
            public string email;
            public string body;
        }

        private async void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Task<string> task = new Task<string>(LoadJson);
            task.Start();
            label1.Text = "Processing file please wait ....";
            var outa = await task;
            textBox1.Text = outa;
            label1.Text = "";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
