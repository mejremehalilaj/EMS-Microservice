import { Module } from '@nestjs/common';
import { ForumMembersService } from './forum_members.service';
import { ForumMembersController } from './forum_members.controller';
import { ForumMember } from './entities/forum_member.entity';
import { TypeOrmModule } from '@nestjs/typeorm';

@Module({
  imports: [TypeOrmModule.forFeature([ForumMember])],
  controllers: [ForumMembersController],
  providers: [ForumMembersService],
})
export class ForumMembersModule {}
