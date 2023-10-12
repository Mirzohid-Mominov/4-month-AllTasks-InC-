
using Delegate_Example;

var postA = new List<BlogPostA>
{
    new(Guid.Parse("5ED80943-8950-48B2-A5EC-28F5F143C968"), "SunLight", "rising"),
    new(Guid.Parse("5E172C91-79A9-4FD4-8BE1-78C2DA576E61"), "Moon", "shining")
};

var postB = new List<BlogPostA>
{
    new(Guid.Parse("5ED80943-8950-48B2-A5EC-28F5F143C968"), "About fish", "sdfg"),
    new(Guid.Parse("5E172C91-79A9-4FD4-8BE1-78C2DA576E61"), "About Students", "sdfg")
};

var posts = postA.ZipIntersectBy(postB, post => post.Id);

foreach (var (post1, post2) in posts)
{
    Console.WriteLine($"Eskisi - {post1.Topic} : {post1.Title}");
    Console.WriteLine($"Yangisi - {post2.Topic} : {post2.Title}");
}

public class BlogPostA
{
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public string Title { get; set; }

    public BlogPostA(Guid id, string topic, string title)
    {
        Id = id;
        Topic = topic;
        Title = title;
    }
}
