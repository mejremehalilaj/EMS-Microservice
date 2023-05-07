import { Controller } from '@nestjs/common';
import { MessagePattern, Payload } from '@nestjs/microservices';
import { ForumService } from './forum.service';
import { CreateForumDto } from './dto/create-forum.dto';
import { UpdateForumDto } from './dto/update-forum.dto';
import { FindOptionsWhere } from 'typeorm';
import { Forum } from './entities/forum.entity';

@Controller()
export class ForumController {
  constructor(private readonly forumService: ForumService) {}

  @MessagePattern({ cmd: 'find_all_forums' })
  findAll() {
    return this.forumService.findAll();
  }

  @MessagePattern({ cmd: 'find_one_forum_by' })
  findOneBy(
    @Payload() where: FindOptionsWhere<Forum> | FindOptionsWhere<Forum>[],
  ) {
    return this.forumService.findOneBy(where);
  }

  @MessagePattern({ cmd: 'create_forum' })
  create(@Payload() createForumDto: CreateForumDto) {
    return this.forumService.create(createForumDto);
  }

  @MessagePattern({ cmd: 'update_forum' })
  update(@Payload() updateForumDto: UpdateForumDto) {
    return this.forumService.update(updateForumDto.id, updateForumDto);
  }

  @MessagePattern({ cmd: 'remove_forum' })
  remove(@Payload() id: string) {
    return this.forumService.remove(id);
  }
}
