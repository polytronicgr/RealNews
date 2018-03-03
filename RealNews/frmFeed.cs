﻿using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealNews
{
    public partial class frmFeed : Form
    {
        public frmFeed()
        {
            InitializeComponent();
        }

        public Feed feed;
        public Feed ret;

        private void button3_Click(object sender, EventArgs e)
        {
            ret = feed;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFeed_Load(object sender, EventArgs e)
        {
            if (feed == null)
                feed = new Feed();

            txtURL.Text = feed.URL;
            txtName.Text = feed.Title;
            chkRTL.Checked = feed.RTL;
            chkImages.Checked = feed.DownloadImages;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // save button
            ret = new Feed
            {
                Title = txtName.Text,
                URL = txtURL.Text,
                DownloadImages = chkImages.Checked,
                RTL = chkRTL.Checked,
                UpdateEveryMin = (int)numUpdate.Value 
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // read feed header info
            txtName.Text = GetInfo(txtURL.Text);
        }

        private string GetInfo(string url)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls  | SecurityProtocolType.Ssl3;
                mWebClient wc = new mWebClient();
                wc.Encoding = Encoding.UTF8;
                if (Settings.UseSytemProxy)
                    wc.Proxy = WebRequest.DefaultWebProxy;
                var feedxml = wc.DownloadString(url);
                var reader = FeedReader.ReadFromString(feedxml);
                return reader.Title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return "";
            }
        }
    }
}