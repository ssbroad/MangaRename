using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaRename
{
    public partial class Form1 : Form
    {

        List<string> new_Folder = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            string path = FolderPath.Text;
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            List<string> showinfos = new List<string>();
            List<string> group_artists = new List<string>();
            List<string[]> artists = new List<string[]>();
            foreach (var file in files)
            {
                bool find = false;
                string fullpath = file.FullName;
                string name = file.Name;
                string group_artist = "test";
                string group = "test";
                string artist = "test";
                //ShowInfo.Text += name + "\r\n";
                if (Regex.Match(name, "(?<=\\[).*\\(.*\\)(?=])").Value != "")
                {
                    group_artist = Regex.Match(name, "(?<=\\[).*\\(.*\\)(?=])").Value;
                    
                    group = Regex.Match(group_artist, ".*(?=\\()").Value;
                    artist = Regex.Match(group_artist, "(?<=\\().*(?=\\))").Value;
                    //ShowInfo.Text += group_artist + "\r\n";
                }
                else if (Regex.Match(name, "(?<=\\[)[^\\[\\]]*(?=])").Value != "")
                {
                    artist = Regex.Match(name, "(?<=\\[)[^\\[\\]]*(?=])").Value;
                    //artists.Add(new string[] { artist, name });
                    //ShowInfo.Text += artist + "\r\n";
                }
                foreach (var dic in dics)
                {
                    string dic_name = dic.Name;
                    //dic_name.Contains
                    if (dic_name.Contains(group) || dic_name.Contains(artist))
                    {
                        find = true;
                        //File.Move(fullpath, dic.FullName + "\\" + name);
                        showinfos.Add(dic_name + " --> " + name + "\r\n");
                        //ShowInfo.Text += dic_name + " --> " + name + "\r\n";
                    }
                    //else if (artist == dic_name)
                    //{
                    //    find = true;
                    //    //File.Move(fullpath, dic.FullName + "\\" + name);
                    //    ShowInfo.Text += dic_name + " --> " + name + "\r\n";
                    //}
                }
                if (!find)
                {
                    if (artist.Contains("中国翻訳"))
                    {
                        showinfos.Add("发现匹配特例 - " + name + "\r\n");
                        //ShowInfo.Text += "发现匹配特例 - " + name + "\r\n";
                    }
                    else
                    {
                        if (group_artist != "test")
                        {
                            group_artists.Add(group_artist);
                            showinfos.Add("未找到对应目录 - " + group_artist + " / " + name + "\r\n");
                        }
                        else if(artist!= "test")
                        {
                            artists.Add(new string[] { artist, name });
                            //showinfos.Add("未找到对应目录 - " + artist + " / " + name + "\r\n");
                        }
                        //showinfos.Add("未找到对应目录 - " + name + "\r\n");
                        //ShowInfo.Text += "未找到对应目录 - " + name + "\r\n";
                    }
                }
            }
            foreach (var artist in artists)
            {
                bool find = false;
                foreach (var group_artist in group_artists)
                {
                    if (group_artist.Contains(artist[0]))
                    {
                        showinfos.Add("未找到对应目录 - " + group_artist + " / " + artist[1] + "\r\n");
                        find = true;
                    }
                }
                if (!find)
                {
                    showinfos.Add("未找到对应目录 - " + artist[0] + " / " + artist[1] + "\r\n");
                }
            }
            new_Folder = group_artists;
            showinfos.Sort();
            foreach (var showinfo in showinfos)
            {
                ShowInfo.Text += showinfo;
            }
        }

        private void Set_Click(object sender, EventArgs e)
        {
            string path = FolderPath.Text;
            foreach (var item in new_Folder)
            {
                Directory.CreateDirectory(path + "\\" + item);
            }
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            FileInfo[] files = root.GetFiles();
            foreach (var file in files)
            {
                bool find = false;
                string fullpath = file.FullName;
                string name = file.Name;
                string group_artist = "test";
                string group = "test";
                string artist = "test";
                if (Regex.Match(name, "(?<=\\[).*\\(.*\\)(?=])").Value != "")
                {
                    group_artist = Regex.Match(name, "(?<=\\[).*\\(.*\\)(?=])").Value;
                    group = Regex.Match(group_artist, ".*(?=\\()").Value;
                    artist = Regex.Match(group_artist, "(?<=\\().*(?=\\))").Value;
                    //ShowInfo.Text += group_artist + "\r\n";
                }
                else if (Regex.Match(name, "(?<=\\[)[^\\[\\]]*(?=])").Value != "")
                {
                    artist = Regex.Match(name, "(?<=\\[)[^\\[\\]]*(?=])").Value;
                    //ShowInfo.Text += artist + "\r\n";
                }
                foreach (var dic in dics)
                {
                    string dic_name = dic.Name;
                    //dic_name.Contains
                    if (dic_name.Contains(group) || dic_name.Contains(artist))
                    {
                        find = true;
                        File.Move(fullpath, dic.FullName + "\\" + name);
                        //showinfos.Add(dic_name + " --> " + name + "\r\n");
                        //ShowInfo.Text += dic_name + " --> " + name + "\r\n";
                    }
                }
                if (!find)
                {
                    Directory.CreateDirectory(path + "\\" + artist);
                    File.Move(fullpath, path + "\\" + artist + "\\" + name);
                    //if (group_artist!= "test")
                    //{
                    //    Directory.CreateDirectory(path+"\\"+ group_artist);
                    //    File.Move(fullpath, path + "\\" + group_artist + "\\" + name);
                    //}
                    //else
                    //{
                    //    Directory.CreateDirectory(path + "\\" + artist);
                    //    File.Move(fullpath, path + "\\" + artist + "\\" + name);
                    //}
                }
            }
        }
    }
}
