import { Injectable } from '@nestjs/common';
import { CreateForumDto } from './dto/create-forum.dto';
import { UpdateForumDto } from './dto/update-forum.dto';
import { InjectRepository } from '@nestjs/typeorm';
import { Forum } from './entities/forum.entity';
import { FindOptionsWhere, Repository } from 'typeorm';

@Injectable()
export class ForumService {
  constructor(
    @InjectRepository(Forum)
    private readonly forumRepository: Repository<Forum>,
  ) {}

  async create(createForumDto: CreateForumDto) {
    const forum = this.forumRepository.create(createForumDto);
    return await this.forumRepository.save(forum);
  }

  async findAll() {
    return await this.forumRepository.find();
  }

  async findOneBy(where: FindOptionsWhere<Forum> | FindOptionsWhere<Forum>[]) {
    return await this.forumRepository.findOneBy(where);
  }

  async update(id: string, updateForumDto: Omit<UpdateForumDto, 'id'>) {
    const forum = await this.findOneBy({ id });
    if (!forum) return null;

    const newForum = this.forumRepository.create(updateForumDto);
    return await this.forumRepository.update(id, newForum);
  }

  async remove(id: string) {
    const forum = await this.findOneBy({ id });
    if (!forum) return null;

    return await this.forumRepository.softRemove({ id });
  }
}
