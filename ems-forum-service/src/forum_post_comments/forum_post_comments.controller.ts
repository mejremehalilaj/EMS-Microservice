import { Controller } from '@nestjs/common';
import { MessagePattern, Payload } from '@nestjs/microservices';
import { ForumPostCommentService } from './forum_post_comments.service';
import { CreateForumPostCommentDto } from './dto/create-forum_post_comment.dto';
import { UpdateForumPostCommentDto } from './dto/update-forum_post_comment.dto';

@Controller()
export class ForumPostCommentController {
  constructor(private readonly forumPostservice: ForumPostCommentService) {}

  @MessagePattern({ cmd: 'create_forumPostComment' })
  create(@Payload() createForumPostDto: CreateForumPostCommentDto) {
    return this.forumPostservice.create(createForumPostDto);
  }

  @MessagePattern({ cmd: 'update_forumPostComment' })
  update(@Payload() updateForumPostDto: UpdateForumPostCommentDto) {
    return this.forumPostservice.update(
      updateForumPostDto.id,
      updateForumPostDto,
    );
  }

  @MessagePattern({ cmd: 'remove_forumPostComment' })
  remove(@Payload() id: string) {
    return this.forumPostservice.remove(id);
  }
}
