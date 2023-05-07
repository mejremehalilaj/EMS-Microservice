import { Controller } from '@nestjs/common';
import { MessagePattern, Payload } from '@nestjs/microservices';
import { FindOptionsWhere } from 'typeorm';
import { CreateForumPostDto } from './dto/create-forum_post.dto';
import { UpdateForumPostDto } from './dto/update-forum_post.dto';
import { ForumPostsService } from './forum_posts.service';
import { ForumPost } from './entities/forum_post.entity';

@Controller()
export class ForumPostsController {
  constructor(private readonly forumPostservice: ForumPostsService) {}

  @MessagePattern({ cmd: 'find_all_forumPosts' })
  findAll() {
    return this.forumPostservice.findAll();
  }

  @MessagePattern({ cmd: 'find_one_forumPost_by' })
  findOneBy(
    @Payload()
    where: FindOptionsWhere<ForumPost> | FindOptionsWhere<ForumPost>[],
  ) {
    return this.forumPostservice.findOneBy(where);
  }

  @MessagePattern({ cmd: 'create_forumPost' })
  create(@Payload() createForumPostDto: CreateForumPostDto) {
    return this.forumPostservice.create(createForumPostDto);
  }

  @MessagePattern({ cmd: 'update_forumPost' })
  update(@Payload() updateForumPostDto: UpdateForumPostDto) {
    return this.forumPostservice.update(
      updateForumPostDto.id,
      updateForumPostDto,
    );
  }

  @MessagePattern({ cmd: 'remove_forumPost' })
  remove(@Payload() id: string) {
    return this.forumPostservice.remove(id);
  }
}
