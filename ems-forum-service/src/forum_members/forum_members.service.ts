import { Injectable } from '@nestjs/common';
import { CreateForumMemberDto } from './dto/create-forum_member.dto';
import { UpdateForumMemberDto } from './dto/update-forum_member.dto';
import { InjectRepository } from '@nestjs/typeorm';
import { ForumMember } from './entities/forum_member.entity';
import { FindOptionsWhere, Repository } from 'typeorm';

@Injectable()
export class ForumMembersService {
  constructor(
    @InjectRepository(ForumMember)
    private readonly forumMembersRepository: Repository<ForumMember>,
  ) {}

  async create(createForumMembersDto: CreateForumMemberDto) {
    const forumMembers = this.forumMembersRepository.create(
      createForumMembersDto,
    );
    return await this.forumMembersRepository.save(forumMembers);
  }

  async findAll() {
    return await this.forumMembersRepository.find();
  }

  async findOneBy(
    where: FindOptionsWhere<ForumMember> | FindOptionsWhere<ForumMember>[],
  ) {
    return await this.forumMembersRepository.findOneBy(where);
  }

  async update(
    id: string,
    updateForumMembersDto: Omit<UpdateForumMemberDto, 'id'>,
  ) {
    const forumMember = await this.findOneBy({ id });
    if (!forumMember) return null;

    const newForumMember = this.forumMembersRepository.create(
      updateForumMembersDto,
    );
    return await this.forumMembersRepository.update(id, newForumMember);
  }

  async remove(id: string) {
    const forumMember = await this.findOneBy({ id });
    if (!forumMember) return null;

    return await this.forumMembersRepository.softRemove({ id });
  }
}
