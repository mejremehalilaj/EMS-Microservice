import { PartialType } from '@nestjs/mapped-types';
import { CreateForumPostCommentDto } from './create-forum_post_comment.dto';

export class UpdateForumPostCommentDto extends PartialType(
  CreateForumPostCommentDto,
) {
  id: string;
}
