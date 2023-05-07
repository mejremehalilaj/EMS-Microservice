import { Controller } from '@nestjs/common';
import { MessagePattern, Payload } from '@nestjs/microservices';
import { ForumMembersService } from './forum_members.service';
import { CreateForumMemberDto } from './dto/create-forum_member.dto';
import { UpdateForumMemberDto } from './dto/update-forum_member.dto';
import { FindOptionsWhere } from 'typeorm';
import { ForumMember } from './entities/forum_member.entity';

@Controller()
export class ForumMembersController {
  constructor(private readonly forumMemberService: ForumMembersService) {}

  @MessagePattern({ cmd: 'find_all_forumMembers' })
  findAll() {
    return this.forumMemberService.findAll();
  }

  @MessagePattern({ cmd: 'find_one_forumMember_by' })
  findOneBy(
    @Payload()
    where: FindOptionsWhere<ForumMember> | FindOptionsWhere<ForumMember>[],
  ) {
    return this.forumMemberService.findOneBy(where);
  }

  @MessagePattern({ cmd: 'create_forumMember' })
  create(@Payload() createForumMemberDto: CreateForumMemberDto) {
    return this.forumMemberService.create(createForumMemberDto);
  }

  @MessagePattern({ cmd: 'update_forumMember' })
  update(@Payload() updateForumMemberDto: UpdateForumMemberDto) {
    return this.forumMemberService.update(
      updateForumMemberDto.id,
      updateForumMemberDto,
    );
  }

  @MessagePattern({ cmd: 'remove_forumMember' })
  remove(@Payload() id: string) {
    return this.forumMemberService.remove(id);
  }
}
