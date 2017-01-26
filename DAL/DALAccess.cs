using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALAccess
    {
        public CA2DB db;

        public DALAccess()
        {
            db = new CA2DB();
        }

        public void InitArticle()
        {
            Article a1 = new Article()
            {
                ID = 1,
                Title = "Hello You Web Voyager!",
                Content = "Are you a random information junkie just floating through cyber space? Have you been following click-bait breadcrumbs in pursuit of that information high all us civilized westerners crave for? Of course you have not; you are a respectful and productive human being and you don’t have any addictions, because addictions are for poor people, and weak people. You’re probably at work.<br><br> Well maybe not, but at least you’re working on yourself.<br><br> That’s what you were doing wasn’t it? Working on yourself? Regardless of your shady intentions, I’m glad that you’ve ended up here, because you’ve washed up at the doorstep of a very special community. A community focused upon human empowerment. <br><br> I guess it’s worth explaining that most of us humans are in a mindset of dis-empowerment, which I like to call a passive mindset of alienated consumption, which is a fancy way of saying that we are slaves. The master we serve is our desires of comfort and greed, and the culture we have built up around these feelings has become our prison.<br><br> I know, yeah, heavy… But I’m not here to despair, I’m here to show you a community which is doing something about it. This community of ours focuses on teaching people to change this mindset, by following a simple premise: “We have to stop consuming our culture. We have to create culture.“<br><br> You see all of us have been sitting at a banquet of information since the dawn of the internet, and we all are stuffing our faces with any junk food that we find.<br><br> We are like personal trainers who want you to pick and choose your meals, and search for the steak and salads instead of the McDonalds of the mind! We see you as an athlete who needs to start eating right so that you can start creating and bringing your own unique meal to the banquet table!<br><br> This is our plan to transform our societies from passive consumers into inspired creators, and our strategy in attaining this goal is to create a community built on the feeling of inspiration instead of consumption. In the words of William Blake: “I must create a system, or be enslaved by another man’s. I will not reason and compare: my business is to create”.",
                UserName = "Stephan Fox"
            };
            db.Articles.Add(a1);
            db.SaveChanges();
        }

        public int GetNumberOfTable(string table)
        {
            switch (table.ToLower())
            {
                case "forum": 
                    return db.Forums.Count();

                case "article":
                    return db.Articles.Count();

                case "post":
                    return db.Posts.Count();

                case "comment":
                    return db.Comments.Count();

                default:
                    throw new Exception("switch not working");
            }

        }

        public Article GetArticle(int index)
        {
           var mainArticle = db.Articles.Where(n => n.ID == index);

            return mainArticle.First();
        }

        public void initForum()
        {
            //inits a forum for music and creates 2 posts for different types of music and comments on each
            Post p1 =new Post() {
                ID = 1,
                Title = "Rock"
            };

            Post p2 = new Post()
            {
                ID = 2,
                Title = "Dance"
            };

            Forum f1 = new Forum()
            {
                ID = 1,
                Title = "Music",
            };

            Comment c1 = new Comment()
            {
                ID = 1,
                Content = "I love music",
                Post = p1
                
            };

            Comment c2 = new Comment()
            {
                ID = 2,
                Content = "I hate music",
                Post = p2
            };
            p1.Forum = f1;
            p2.Forum = f1;
            ICollection<Comment> comments = new List<Comment>();
            ICollection<Comment> comments1 = new List<Comment>();
            comments.Add(c1);
            comments1.Add(c2);
            ICollection<Post> posts = new List<Post>();
            posts.Add(p1);
            posts.Add(p2);
            p1.Comments = comments;
            p2.Comments = comments1;

            f1.Posts = posts;

            db.Forums.Add(f1);
            db.SaveChanges();
        }

        public void addNewForum(Forum newForum)
        {
            db.Forums.Add(newForum);
            db.SaveChanges();
        }

        public void addForumPost(Post post, long forumID)
        {
            var addPostToForum = db.Forums.Where(n => n.ID == forumID).FirstOrDefault();
            addPostToForum.Posts.Add(post);

            db.SaveChanges();
        }

        public IEnumerable<Forum> getForums()
        {
          
            return db.Forums.ToList();
        }

        public Post getPost(int postID)
        {
            var postToDisplay = db.Posts.Where(n => n.ID == postID).FirstOrDefault();
            return postToDisplay;
        }

        public Post getPost(int forumId, int postId)
        {
            var forumWithPost = db.Forums.Where(n => n.ID == forumId).FirstOrDefault();
            var postToDisplay = forumWithPost.Posts.Where(n => n.ID == postId).FirstOrDefault();
            return postToDisplay;
        }

        public void removeItem(long itemID, string itemName)
        {
            switch (itemName.ToLower())
            {
                case "forum":
                    Forum forumToDelete = db.Forums.Find(itemID);
                    db.Posts.RemoveRange(db.Posts.Where(n => n.Forum.ID == itemID));
                    db.Forums.Remove(forumToDelete);
                    db.SaveChanges();
                    break;
                case "post":
                    Post postToDelete = db.Posts.Find(itemID);
                    db.Comments.RemoveRange(db.Comments.Where(n => n.Post.ID == itemID));
                    db.Posts.Remove(postToDelete);
                    db.SaveChanges();
                    break;
                case "comment":
                    Comment commentToDelete = db.Comments.Find(itemID);
                    db.Comments.Remove(commentToDelete);
                    db.SaveChanges();
                    break;
            }
        }

        public void addComment(Comment comment, long postID)
        {
            var addCommentToPost = db.Posts.Where(n => n.ID == postID).FirstOrDefault();
            addCommentToPost.Comments.Add(comment);
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public IEnumerable<Forum> forumOrdered(List<Forum> forum)
        {
            return db.Forums.OrderByDescending(n => n.ID);
        }

    }
}
