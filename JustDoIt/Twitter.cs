using System;
using System.Collections.Generic;

namespace JustDoIt
{
    public class Tweet
    {
        public int Id;
        public Tweet Next;
        public int Timestamp;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="timestamp"></param>
        public Tweet(int id, int timestamp)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            Next = null;
        }
    }

    public class User
    {
        private int _userId;
        private Tweet _tweetHead;
        private HashSet<int> _follow;

        public User(int userId)
        {
            _userId = userId;
            _tweetHead = null;
            _follow = new HashSet<int>();
            Follow(_userId);
        }

        public void Follow(int userId)
        {
            if (!_follow.Contains(userId))
                _follow.Add(userId);
        }

        public void Unfollow(int userId)
        {
            _follow.Remove(userId);
        }

        public void PostTweet(Tweet tweet)
        {
            if (_tweetHead == null)
                _tweetHead = tweet;
            else
            {
                tweet.Next = _tweetHead;
                _tweetHead = tweet;
            }
        }
    }




    public class Twitter
    {
        private Dictionary<int, TwitterUser> _users;
        private const int MAX_NEWS_FEEDS_TO_FETCH = 10;
        private int tweetOrder = 0;
        
        

        /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */

        /** Initialize your data structure here. */
        public Twitter()
        {
            _users = new Dictionary<int, TwitterUser>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (_users.TryGetValue(userId, out TwitterUser user))
            {
                user.AddTweet(tweetId, ++tweetOrder);
            }
            else
            {
                var nuser = new TwitterUser(userId);
                nuser.Following.Add(nuser);
            }
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed.
         * Each item in the news feed must be posted
         * by users who the user followed or by the user herself.
         * Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            IList<int> newsFeed = new List<int>();

            if (_users.TryGetValue(userId, out TwitterUser user))
            {
                var newsFeeds = user.Tweets.GetEnumerator();
                int count = 0;
                while (count < MAX_NEWS_FEEDS_TO_FETCH && newsFeeds.MoveNext())
                {
                    //newsFeed.Add(newsFeeds.Current);
                    count++;
                }
            }

            return newsFeed;
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {            
            //if (_users.TryGetValue(followerId, out var follower))
            //    follower.Following.Add(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            //if (_users.TryGetValue(followerId, out var follower))
            //    follower.Following.Remove(followeeId);
        }
    }


    public class TwitterUser
    {
        /// <summary>
        /// Twitter User Id
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// News Feed
        /// </summary>
        public List<Tweet> Tweets { get; private set; }

        public List<TwitterUser> Following { get; private set; }

        /// <summary>
        /// Initialize TwitterUser
        /// </summary>
        /// <param name="userId"></param>
        public TwitterUser(int userId)
        {
            this.UserId = userId;
            this.Tweets = new List<Tweet>();
            this.Following = new List<TwitterUser>();
        }

        public void AddTweet(int tweetId, int timestamp)
        {
            this.Tweets.Add(new Tweet(tweetId, timestamp));
        }
    }
}
