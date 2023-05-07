import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { CreateForumPostCommentDto } from './dto/create-forum_post_comment.dto';
import { ForumPostComment } from './entities/forum_post_comment.entity';
import { UpdateForumPostCommentDto } from './dto/update-forum_post_comment.dto';

@Injectable()
export class ForumPostCommentService {
  constructor(
    @InjectRepository(ForumPostComment)
    private readonly forumPostCommentRepository: Repository<ForumPostComment>,
  ) {}

  async create(createForumPostCommentDto: CreateForumPostCommentDto) {
    const forumPostComment = this.forumPostCommentRepository.create(
      createForumPostCommentDto,
    );
    return await this.forumPostCommentRepository.save(forumPostComment);
  }

  async update(
    id: string,
    updateForumPostCommentDto: Omit<UpdateForumPostCommentDto, 'id'>,
  ) {
    const updatedForumPostComment = this.forumPostCommentRepository.create(
      updateForumPostCommentDto,
    );
    return await this.forumPostCommentRepository.update(
      id,
      updatedForumPostComment,
    );
  }

  async remove(id: string) {
    return await this.forumPostCommentRepository.softRemove({ id });
  }
}
