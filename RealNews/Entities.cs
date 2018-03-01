﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace RealNews
{
    public class Feed
    {
        public int id;
        public string URL = "";
        public string Title = "";
        public string IconName;
        public bool RTL;
        public DateTime LastUpdate;
        public int UpdateEveryHour;
        public bool DownloadImages = true;
        public DateTime LastItemDate;
        public string LastError;
        public int UpdateEveryMin = -1; // use global settings else e.g. 8*60 min
        public int UnreadCount = 0;
        public bool feediconfailed = false;
    }


    public class FeedItem
    {
        public string Title;
        public string Link;
        public string Categories;
        public DateTime date;
        public string Author;
        public string Id;

        public string Description;
        public int feedid;
        public string Attachment;

        public bool isRead = false;
        public bool isStarred = false; // fix : set starred
    }

    class FeedItemComparer : IEqualityComparer<FeedItem>
    {
        public bool Equals(FeedItem p1, FeedItem p2)
        {
            return p1.Title == p2.Title;
        }

        public int GetHashCode(FeedItem p)
        {
            return p.Title.GetHashCode();
        }
    }

    class listviewcompare : IComparer
    {
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}
