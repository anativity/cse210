using System;

public class Video
{
    
    private int _length;
    private string _title;
    private string _author;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
      _title = title;
      _author = author;
      _length = length;  
    }
        
    public void NewComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public string GetDisplayVideo()
    {
        return $"{_title} by {_author} ({_length} seconds)\nComments: {GetNumComments()}";
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}