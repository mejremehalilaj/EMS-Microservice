import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { DatabaseModule } from './database/database.module';
import { ForumModule } from './forum/forum.module';
import { ForumMembersModule } from './forum_members/forum_members.module';

@Module({
  imports: [ConfigModule.forRoot(), DatabaseModule, ForumModule, ForumMembersModule],
})
export class AppModule {}
