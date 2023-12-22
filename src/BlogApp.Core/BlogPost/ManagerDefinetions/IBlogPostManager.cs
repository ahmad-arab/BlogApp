using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core
{
    /// <summary>
    /// A manager to make all possible actions on blog posts
    /// </summary>
    public interface IBlogPostManager
    {
        /// <summary>
        /// All blog posts as queryable
        /// </summary>
        IQueryable<BlogPost> BlogPosts { get; }

        /// <summary>
        /// Load all information related to the specified blog post,
        /// Including author, post interactions, comments, comments authors, comments interactions and child comments
        /// </summary>
        /// <param name="id">The Id of the blog post</param>
        /// <param name="forEditing">If true, Only required information for editing are loaded, No comments nor interactions</param>
        /// <returns>Returns a <see cref="BlogPost"/></returns>
        Task<BlogPost> GetBlogPostByIdAsync(Guid id, bool forEditing);

        /// <summary>
        /// Lists blog posts, Getting only basic info of the post, No navigation properties are loaded except for author
        /// If any parameter is null it will get all posts, Otherwise it will get paged result  
        /// </summary>
        /// <param name="pageSize">The number of blog posts per page</param>
        /// <param name="pageNumber">Page number</param>
        /// <returns></returns>
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync(int? pageSize = null, int? pageNumber = null);

        /// <summary>
        /// Adds a blog post
        /// </summary>
        /// <param name="blogPost">The post to add</param>
        /// <returns>The Id of the newly added post</returns>
        Task<Guid> AddBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Updates a blog post
        /// </summary>
        /// <param name="blogPost">The post to update</param>
        /// <returns></returns>
        Task UpdateBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="id">The Id of the blog post to delete</param>
        /// <returns></returns>
        Task DeleteBlogPostAsync(Guid id);

        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="blogPost">The blog post to delete</param>
        /// <returns></returns>
        Task DeleteBlogPostAsync(BlogPost blogPost);

        /// <summary>
        /// Adds a comment
        /// </summary>
        /// <param name="comment">The comment to add</param>
        /// <returns>The Id of the newly added comment</returns>
        Task<Guid> AddCommentAsync(Comment comment);

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="comment">The Comment to update</param>
        /// <returns></returns>
        Task UpdateCommentAsync(Comment comment);

        /// <summary>
        /// Deletes a Comment
        /// </summary>
        /// <param name="id">The Id of the comment to delete</param>
        /// <returns></returns>
        Task DeleteCommentAsync(Guid id);

        /// <summary>
        /// Deletes a Comment
        /// </summary>
        /// <param name="comment">The comment to delete</param>
        /// <returns></returns>
        Task DeleteCommentAsync(Comment comment);

        /// <summary>
        /// Adds a blog post interaction
        /// </summary>
        /// <param name="blogPostInteraction">The post interaction to add</param>
        /// <returns>The Id of the newly added post interaction</returns>
        Task<Guid> AddBlogPostInteractionAsync(BlogPostInteraction blogPostInteraction);

        /// <summary>
        /// Updates a blog post interaction
        /// </summary>
        /// <param name="blogPostInteraction">The post interaction to update</param>
        /// <returns></returns>
        Task UpdateBlogPostInteractionAsync(BlogPostInteraction blogPostInteraction);

        /// <summary>
        /// Deletes a blog post interaction
        /// </summary>
        /// <param name="id">The Id of the blog post interaction to delete</param>
        /// <returns></returns>
        Task DeleteBlogPostInteractionAsync(Guid id);

        /// <summary>
        /// Deletes a blog post interaction
        /// </summary>
        /// <param name="blogPostInteraction">The blog post interaction to delete</param>
        /// <returns></returns>
        Task DeleteBlogPostInteractionAsync(BlogPostInteraction blogPostInteraction);

        /// <summary>
        /// Adds a comment interaction
        /// </summary>
        /// <param name="commentInteraction">The comment interaction to add</param>
        /// <returns>The Id of the newly added comment interaction</returns>
        Task<Guid> AddCommentInteractionAsync(CommentInteraction commentInteraction);

        /// <summary>
        /// Updates a comment interaction
        /// </summary>
        /// <param name="commentInteraction">The comment interaction to update</param>
        /// <returns></returns>
        Task UpdateCommentInteractionAsync(CommentInteraction commentInteraction);

        /// <summary>
        /// Deletes a comment interaction
        /// </summary>
        /// <param name="id">The Id of the comment interaction to delete</param>
        /// <returns></returns>
        Task DeleteCommentInteractionAsync(Guid id);

        /// <summary>
        /// Deletes a comment interaction
        /// </summary>
        /// <param name="commentInteraction">The comment interaction to delete</param>
        /// <returns></returns>
        Task DeleteCommentInteractionAsync(CommentInteraction commentInteraction);

        /// <summary>
        /// Publishes the specified blog post
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        Task PublishBlogPost(BlogPost blogPost);

        /// <summary>
        /// Publishes the specified blog post
        /// </summary>
        /// <param name="blogPostId"></param>
        /// <returns></returns>
        Task PublishBlogPost(Guid blogPostId);

        /// <summary>
        /// Unpublishes the specified blog post
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        Task UnpublishBlogPost(BlogPost blogPost);

        /// <summary>
        /// Unpublishes the specified blog post
        /// </summary>
        /// <param name="blogPostId"></param>
        /// <returns></returns>
        Task UnpublishBlogPost(Guid blogPostId);
    }
}
