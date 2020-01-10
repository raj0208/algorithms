using System;
using System.Collections.Generic;

namespace JustDoIt
{
    public class Twitter
    {
        private Dictionary<int, TwitterUser> _users;
        private const int MAX_NEWS_FEEDS_TO_FETCH = 10;

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
                user.AddTweet(tweetId);

                foreach (var followeeId in user.Following)
                {
                    _users[followeeId].AddTweet(tweetId);
                }
            }
            else
            {
                user = new TwitterUser(userId);
                user.NewsFeeds.AddFirst(tweetId);
                _users[userId] = user;
            }
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            IList<int> newsFeed = new List<int>();

            if (_users.TryGetValue(userId, out TwitterUser user))
            {
                var newsFeeds = user.NewsFeeds;

                for (int i = 0; i < MAX_NEWS_FEEDS_TO_FETCH; i++)
                {
                    //newsFeed.Add()
                }
            }

            return newsFeed;

        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {

        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {

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
        public LinkedList<int> NewsFeeds { get; private set; }

        public HashSet<int> Following { get; private set; }

        /// <summary>
        /// Initialize TwitterUser
        /// </summary>
        /// <param name="userId"></param>
        public TwitterUser(int userId)
        {
            this.UserId = userId;
            this.NewsFeeds = new LinkedList<int>();
            this.Following = new HashSet<int>();
        }

        public void AddTweet(int tweetId)
        {
            this.NewsFeeds.AddFirst(tweetId);
        }
    }
}
