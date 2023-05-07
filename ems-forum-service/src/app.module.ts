import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { DatabaseModule } from './database/database.module';
import { ForumModule } from './forum/forum.module';
import { ForumMembersModule } from './forum_members/forum_members.module';
import { ForumPostsModule } from './forum_posts/forum_posts.module';
import { ForumPostCommentsModule } from './forum_post_comments/forum_post_comments.module';

@Module({
  imports: [ConfigModule.forRoot(), DatabaseModule, ForumModule, ForumMembersModule, ForumPostsModule, ForumPostCommentsModule],
})
export class AppModule {}
