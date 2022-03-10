using System;

public class FacebookAccount
{
	private string _name { get; set; }
	private string _email { get; set; }
	private string _mobileNumber { get; set; }
	private string _userId;
	private List<FriendRequest> _friendRequests;
	private List<FacebookPost> _posts;
	private List<FacebookStory> _stories;
	private List<FacebookPage> _pages;
	private List<FacebookGroup> _groups;

	public void CreateNewPost() { }
	public void CreateNewStory() { }
	public void CreateNewPage() { }
	public void SendFriendRequest(string username) { }
	public void AcceptFriendRequest(string username) { }
	public void ReactOnPost(string PostURL)
    {
		//to like,comment or share a post
    }

}

public class FriendRequest
{
	private string _sentFromUserName { get; set; }
	private string _sentToUserName { get; set; }
	private DateOnly _sentOnDate { get; set; }
}
public class FacebookPost
{
	private int _postId;
	private string _postTitle { get; set; }
	private string _postContent { get; set; }
	private string _postUrl { get; set; }
	private DateTime _postedOnDateTime { get; set; }

}

public class FacebookGroup
{
	private int _gropuId { get; set; }
	private int _groupId { get; set; }
	private string _groupName { get; set; }
	private List<string> _groupMemberUserNames;
}
public class FacebookPage
{
	private int _pageId;
	private string _pageTitle { get; set; }
	private string _pageURL { get; set; }
}
public class FacebookStory
{
	private int _storyId;
	private DateTime _postedOnDateTime { get; set; }
	private string _storyMessage { get; set; }
	private string _storyURL { get; set; }
}