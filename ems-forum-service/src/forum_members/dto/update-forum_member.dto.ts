import { PartialType } from '@nestjs/mapped-types';
import { CreateForumMemberDto } from './create-forum_member.dto';

export class UpdateForumMemberDto extends PartialType(CreateForumMemberDto) {
  id: string;
}
