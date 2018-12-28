using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.DataAccess.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000000_InitialCreate")]
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"IF NOT EXISTS(SELECT *
FROM sys.schemas
WHERE name = N'dbo')
EXEC('CREATE SCHEMA [dbo] AUTHORIZATION [dbo]');
GO

--IF (OBJECT_ID('dbo.FK_Direct_Tweets_tagged_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Direct_Tweets] DROP CONSTRAINT [FK_Direct_Tweets_tagged_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Follower_followed_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Follower] DROP CONSTRAINT [FK_Follower_followed_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Follower_following_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Follower] DROP CONSTRAINT [FK_Follower_following_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Like_liker_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Like] DROP CONSTRAINT [FK_Like_liker_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Like_tweet_id_Tweet_tweet_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Like] DROP CONSTRAINT [FK_Like_tweet_id_Tweet_tweet_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Message_sender_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_sender_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Messenger_to_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Messenger] DROP CONSTRAINT [FK_Messenger_to_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Messenger_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Messenger] DROP CONSTRAINT [FK_Messenger_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Messenger_message_id_Message_message_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Messenger] DROP CONSTRAINT [FK_Messenger_message_id_Message_message_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Quote_Tweet_source_tweet_id_Tweet_tweet_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Quote_Tweet] DROP CONSTRAINT [FK_Quote_Tweet_source_tweet_id_Tweet_tweet_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Quote_Tweet_retweeter_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Quote_Tweet] DROP CONSTRAINT [FK_Quote_Tweet_retweeter_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Reply_replier_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Reply] DROP CONSTRAINT [FK_Reply_replier_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Retweet_retwitter_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Retweet] DROP CONSTRAINT [FK_Retweet_retwitter_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Retweet_tweet_tweet_id_Tweet_tweet_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Retweet] DROP CONSTRAINT [FK_Retweet_tweet_tweet_id_Tweet_tweet_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Tweet_location_id_Location_location_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Tweet] DROP CONSTRAINT [FK_Tweet_location_id_Location_location_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_Tweet_user_user_id_User_user_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[Tweet] DROP CONSTRAINT [FK_Tweet_user_user_id_User_user_id]
--END
--GO
--IF (OBJECT_ID('dbo.FK_User_location_location_id_Location_location_id', 'F') IS NOT NULL)
--BEGIN
--ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_location_location_id_Location_location_id]
--END
--GO

--IF OBJECT_ID('dbo.Direct_Tweets', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Direct_Tweets]
--END
--GO
--IF OBJECT_ID('dbo.Follower', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Follower]
--END
--GO
--IF OBJECT_ID('dbo.Following', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Following]
--END
--GO
--IF OBJECT_ID('dbo.Like', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Like]
--END
--GO
--IF OBJECT_ID('dbo.Location', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Location]
--END
--GO
--IF OBJECT_ID('dbo.Message', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Message]
--END
--GO
--IF OBJECT_ID('dbo.Messenger', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Messenger]
--END
--GO
--IF OBJECT_ID('dbo.Quote_Tweet', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Quote_Tweet]
--END
--GO
--IF OBJECT_ID('dbo.Reply', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Reply]
--END
--GO
--IF OBJECT_ID('dbo.Retweet', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Retweet]
--END
--GO
--IF OBJECT_ID('dbo.Tweet', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[Tweet]
--END
--GO
--IF OBJECT_ID('dbo.User', 'U') IS NOT NULL 
--BEGIN
--DROP TABLE [dbo].[User]
--END
--GO

CREATE TABLE [dbo].[Direct_Tweets](
[tweet_id] [int]     NOT NULL,
[content] [varchar]  (140)   NOT NULL,
[date] [date]     NOT NULL,
[tagged_user_id] [int]     NOT NULL,
[time] [time]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Follower](
[id] [int]     NOT NULL,
[blocked] [char]  (1)   NOT NULL,
[date_followed] [date]     NOT NULL,
[follow_request_status] [char]  (1)   NOT NULL,
[followed_user_id] [int]     NOT NULL,
[following_user_id] [int]     NOT NULL,
[muted] [char]  (1)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Following](
[user_id] [int]   IDENTITY(1,1)  NOT NULL,
[date_followed] [date]     NULL,
[muted] [char]  (1)   NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Like](
[liker_user_id] [int]     NOT NULL,
[tweet_id] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Location](
[location_id] [int]     NOT NULL,
[gps_lat] [int]     NOT NULL,
[gps_long] [int]     NOT NULL,
[location_name] [varchar]  (64)   NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Message](
[message_id] [int]     NOT NULL,
[content] [varchar]  (128)   NULL,
[sender_user_id] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Messenger](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[date] [date]     NULL,
[from_user_id] [int]     NULL,
[message_id] [int]     NULL,
[time] [time]     NULL,
[to_user_id] [int]     NOT NULL,
[user_id] [int]     NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Quote_Tweet](
[quote_tweet_id] [int]     NOT NULL,
[content] [varchar]  (140)   NOT NULL,
[date] [date]     NOT NULL,
[retweeter_user_id] [int]     NOT NULL,
[source_tweet_id] [int]     NOT NULL,
[time] [time]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Reply](
[reply_id] [int]     NOT NULL,
[content] [varchar]  (140)   NOT NULL,
[date] [date]     NOT NULL,
[replier_user_id] [int]     NOT NULL,
[time] [time]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Retweet](
[id] [int]   IDENTITY(1,1)  NOT NULL,
[date] [date]     NULL,
[retwitter_user_id] [int]     NULL,
[time] [time]     NULL,
[tweet_tweet_id] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[Tweet](
[tweet_id] [int]     NOT NULL,
[content] [varchar]  (140)   NOT NULL,
[date] [date]     NOT NULL,
[location_id] [int]     NOT NULL,
[time] [time]     NOT NULL,
[user_user_id] [int]     NOT NULL,
) ON[PRIMARY]
GO

CREATE TABLE [dbo].[User](
[user_id] [int]     NOT NULL,
[bio_img_url] [varchar]  (32)   NULL,
[birthday] [date]     NULL,
[content_description] [varchar]  (128)   NULL,
[email] [varchar]  (32)   NOT NULL,
[full_name] [varchar]  (64)   NOT NULL,
[header_img_url] [varchar]  (32)   NULL,
[interest] [varchar]  (128)   NULL,
[location_location_id] [int]     NOT NULL,
[password] [varchar]  (32)   NOT NULL,
[phone_number] [varchar]  (32)   NULL,
[privacy] [char]  (1)   NOT NULL,
[username] [varchar]  (64)   NOT NULL,
[website] [varchar]  (32)   NULL,
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[Direct_Tweets]
ADD CONSTRAINT[PK__Direct_T__D29C7047218B8321] PRIMARY KEY CLUSTERED
(
[tweet_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Direct_Tweets_tagged_user_id] ON[dbo].[Direct_Tweets]
(
[tagged_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Follower]
ADD CONSTRAINT[PK_Follower] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Follower_followed_user_id] ON[dbo].[Follower]
(
[followed_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Follower_following_user_id] ON[dbo].[Follower]
(
[following_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Following]
ADD CONSTRAINT[PK__Followin__B9BE370F248238E5] PRIMARY KEY CLUSTERED
(
[user_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE UNIQUE NONCLUSTERED INDEX[UQ__Followin__B9BE370E8C7103D9] ON[dbo].[Following]
(
[user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Like]
ADD CONSTRAINT[PK_Like] PRIMARY KEY CLUSTERED
(
[liker_user_id] ASC
,[tweet_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Like_liker_user_id] ON[dbo].[Like]
(
[liker_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Like_tweet_id] ON[dbo].[Like]
(
[tweet_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Location]
ADD CONSTRAINT[PK__Location__771831EAADC27010] PRIMARY KEY CLUSTERED
(
[location_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Message]
ADD CONSTRAINT[PK__Message__0BBF6EE6C0DC4E0B] PRIMARY KEY CLUSTERED
(
[message_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Message_sender_user_id] ON[dbo].[Message]
(
[sender_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Messenger]
ADD CONSTRAINT[PK_Messenger] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Messenger_message_id] ON[dbo].[Messenger]
(
[message_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Messenger_to_user_id] ON[dbo].[Messenger]
(
[to_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Messenger_user_id] ON[dbo].[Messenger]
(
[user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Quote_Tweet]
ADD CONSTRAINT[PK_Quote_Tweet] PRIMARY KEY CLUSTERED
(
[quote_tweet_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Quote_Tweet_retweeter_user_id] ON[dbo].[Quote_Tweet]
(
[retweeter_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Quote_Tweet_source_tweet_id] ON[dbo].[Quote_Tweet]
(
[source_tweet_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Reply]
ADD CONSTRAINT[PK_Reply] PRIMARY KEY CLUSTERED
(
[reply_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Reply_replier_user_id] ON[dbo].[Reply]
(
[replier_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Retweet]
ADD CONSTRAINT[PK_Retweet] PRIMARY KEY CLUSTERED
(
[id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Retweet_retwitter_user_id] ON[dbo].[Retweet]
(
[retwitter_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Retweet_tweet_tweet_id] ON[dbo].[Retweet]
(
[tweet_tweet_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[Tweet]
ADD CONSTRAINT[PK__Tweet__D29C70471A55E959] PRIMARY KEY CLUSTERED
(
[tweet_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Tweet_location_id] ON[dbo].[Tweet]
(
[location_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_Tweet_user_user_id] ON[dbo].[Tweet]
(
[user_user_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE[dbo].[User]
ADD CONSTRAINT[PK__User__B9BE370F81ECAF43] PRIMARY KEY CLUSTERED
(
[user_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  IGNORE_DUP_KEY = OFF,  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE  NONCLUSTERED INDEX[IX_User_location_location_id] ON[dbo].[User]
(
[location_location_id] ASC)
WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO


ALTER TABLE[dbo].[Direct_Tweets]  WITH CHECK ADD  CONSTRAINT[FK_Direct_Tweets_tagged_user_id_User_user_id] FOREIGN KEY([tagged_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Direct_Tweets] CHECK CONSTRAINT[FK_Direct_Tweets_tagged_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Follower]  WITH CHECK ADD  CONSTRAINT[FK_Follower_followed_user_id_User_user_id] FOREIGN KEY([followed_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Follower] CHECK CONSTRAINT[FK_Follower_followed_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Follower]  WITH CHECK ADD  CONSTRAINT[FK_Follower_following_user_id_User_user_id] FOREIGN KEY([following_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Follower] CHECK CONSTRAINT[FK_Follower_following_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Like]  WITH CHECK ADD  CONSTRAINT[FK_Like_liker_user_id_User_user_id] FOREIGN KEY([liker_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Like] CHECK CONSTRAINT[FK_Like_liker_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Like]  WITH CHECK ADD  CONSTRAINT[FK_Like_tweet_id_Tweet_tweet_id] FOREIGN KEY([tweet_id])
REFERENCES[dbo].[Tweet]([tweet_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Like] CHECK CONSTRAINT[FK_Like_tweet_id_Tweet_tweet_id]
GO
ALTER TABLE[dbo].[Message]  WITH CHECK ADD  CONSTRAINT[FK_Message_sender_user_id_User_user_id] FOREIGN KEY([sender_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Message] CHECK CONSTRAINT[FK_Message_sender_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Messenger]  WITH CHECK ADD  CONSTRAINT[FK_Messenger_to_user_id_User_user_id] FOREIGN KEY([to_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Messenger] CHECK CONSTRAINT[FK_Messenger_to_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Messenger]  WITH CHECK ADD  CONSTRAINT[FK_Messenger_user_id_User_user_id] FOREIGN KEY([user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Messenger] CHECK CONSTRAINT[FK_Messenger_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Messenger]  WITH CHECK ADD  CONSTRAINT[FK_Messenger_message_id_Message_message_id] FOREIGN KEY([message_id])
REFERENCES[dbo].[Message]([message_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Messenger] CHECK CONSTRAINT[FK_Messenger_message_id_Message_message_id]
GO
ALTER TABLE[dbo].[Quote_Tweet]  WITH CHECK ADD  CONSTRAINT[FK_Quote_Tweet_source_tweet_id_Tweet_tweet_id] FOREIGN KEY([source_tweet_id])
REFERENCES[dbo].[Tweet]([tweet_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Quote_Tweet] CHECK CONSTRAINT[FK_Quote_Tweet_source_tweet_id_Tweet_tweet_id]
GO
ALTER TABLE[dbo].[Quote_Tweet]  WITH CHECK ADD  CONSTRAINT[FK_Quote_Tweet_retweeter_user_id_User_user_id] FOREIGN KEY([retweeter_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Quote_Tweet] CHECK CONSTRAINT[FK_Quote_Tweet_retweeter_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Reply]  WITH CHECK ADD  CONSTRAINT[FK_Reply_replier_user_id_User_user_id] FOREIGN KEY([replier_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Reply] CHECK CONSTRAINT[FK_Reply_replier_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Retweet]  WITH CHECK ADD  CONSTRAINT[FK_Retweet_retwitter_user_id_User_user_id] FOREIGN KEY([retwitter_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Retweet] CHECK CONSTRAINT[FK_Retweet_retwitter_user_id_User_user_id]
GO
ALTER TABLE[dbo].[Retweet]  WITH CHECK ADD  CONSTRAINT[FK_Retweet_tweet_tweet_id_Tweet_tweet_id] FOREIGN KEY([tweet_tweet_id])
REFERENCES[dbo].[Tweet]([tweet_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Retweet] CHECK CONSTRAINT[FK_Retweet_tweet_tweet_id_Tweet_tweet_id]
GO
ALTER TABLE[dbo].[Tweet]  WITH CHECK ADD  CONSTRAINT[FK_Tweet_location_id_Location_location_id] FOREIGN KEY([location_id])
REFERENCES[dbo].[Location]([location_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Tweet] CHECK CONSTRAINT[FK_Tweet_location_id_Location_location_id]
GO
ALTER TABLE[dbo].[Tweet]  WITH CHECK ADD  CONSTRAINT[FK_Tweet_user_user_id_User_user_id] FOREIGN KEY([user_user_id])
REFERENCES[dbo].[User]([user_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[Tweet] CHECK CONSTRAINT[FK_Tweet_user_user_id_User_user_id]
GO
ALTER TABLE[dbo].[User]  WITH CHECK ADD  CONSTRAINT[FK_User_location_location_id_Location_location_id] FOREIGN KEY([location_location_id])
REFERENCES[dbo].[Location]([location_id]) on delete no action on update no action
GO
ALTER TABLE[dbo].[User] CHECK CONSTRAINT[FK_User_location_location_id_Location_location_id]
GO

");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
		}
	}
}