import { ForumPostComment } from 'src/forum_post_comments/entities/forum_post_comment.entity';
import { EntityHelper } from 'src/utils/entity-helper.util';
import {
  Column,
  Entity,
  JoinColumn,
  OneToMany,
  PrimaryGeneratedColumn,
} from 'typeorm';

@Entity()
export class ForumPost extends EntityHelper {
  @PrimaryGeneratedColumn('uuid')
  id: string;

  @Column()
  title: string;

  @Column()
  description: string;

  @Column()
  forumId: string;

  @Column()
  userId: string;

  @OneToMany(
    () => ForumPostComment,
    (ForumPostComment) => {
      ForumPostComment.forumPost;
    },
  )
  @JoinColumn()
  comments: ForumPostComment[];
}
