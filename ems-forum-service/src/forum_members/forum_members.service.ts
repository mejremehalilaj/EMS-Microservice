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
    private readonly forumMemberRepository: Repository<ForumMember>,
  ) {}

  async create(createForumMembersDto: CreateForumMemberDto) {
    const forumMembers = this.forumMemberRepository.create(
      createForumMembersDto,
    );
    return await this.forumMemberRepository.save(forumMembers);
  }

  async findAll() {
    return await this.forumMemberRepository.find();
  }

  async findOneBy(
    where: FindOptionsWhere<ForumMember> | FindOptionsWhere<ForumMember>[],
  ) {
    return await this.forumMemberRepository.findOneBy(where);
  }

  async update(
    id: string,
    updateForumMembersDto: Omit<UpdateForumMemberDto, 'id'>,
  ) {
    const forumMembers = await this.findOneBy({ id });
    if (!forumMembers) return null;

    const newForumMembers = this.forumMemberRepository.create(
      updateForumMembersDto,
    );
    return await this.forumMemberRepository.update(id, newForumMembers);
  }

  async remove(id: string) {
    const forumMembers = await this.findOneBy({ id });
    if (!forumMembers) return null;

    return await this.forumMemberRepository.softRemove({ id });
  }
}
