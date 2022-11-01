using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<Post> GetWithRoles()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [User]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";
            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var usr = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (usr == null)
                    {
                        usr = post;
                        if (tag != null)
                            usr.Tags.Add(tag);

                        posts.Add(usr);
                    }
                    else
                        usr.Tags.Add(tag);

                    return post;
                }, splitOn: "Id");

            return posts;
        }
    }
}