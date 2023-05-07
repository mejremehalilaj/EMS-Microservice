import { Injectable } from '@nestjs/common';
import { CreateForumPostDto } from './dto/create-forum_post.dto';
import { UpdateForumPostDto } from './dto/update-forum_post.dto';
import { InjectRepository } from '@nestjs/typeorm';
import { ForumPost } from './entities/forum_post.entity';
import { FindOptionsWhere, Repository } from 'typeorm';

@Injectable()
export class ForumPostsService {
  constructor(
    @InjectRepository(ForumPost)
    private readonly forumPostRepository: Repository<ForumPost>,
  ) {}

  async create(createForumPostsDto: CreateForumPostDto) {
    const forumPosts = this.forumPostRepository.create(createForumPostsDto);
    return await this.forumPostRepository.save(forumPosts);
  }

  async findAll() {
    return await this.forumPostRepository.find();
  }

  async findOneBy(
    where: FindOptionsWhere<ForumPost> | FindOptionsWhere<ForumPost>[],
  ) {
    return await this.forumPostRepository.findOneBy(where);
  }

  async update(
    id: string,
    updateForumPostsDto: Omit<UpdateForumPostDto, 'id'>,
  ) {
    const forumPost = await this.findOneBy({ id });
    if (!forumPost) return null;

    const newForumPost = this.forumPostRepository.create(updateForumPostsDto);
    return await this.forumPostRepository.update(id, newForumPost);
  }

  async remove(id: string) {
    const forumPost = await this.findOneBy({ id });
    if (!forumPost) return null;

    return await this.forumPostRepository.softRemove({ id });
  }
}
