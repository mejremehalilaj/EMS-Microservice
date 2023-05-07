import { ForumPost } from 'src/forum_posts/entities/forum_post.entity';
import { EntityHelper } from 'src/utils/entity-helper.util';
import { Column, Entity, ManyToOne, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class ForumPostComment extends EntityHelper {
  @PrimaryGeneratedColumn('uuid')
  id: string;

  @Column()
  postId: string;

  @Column()
  userId: string;

  @Column({ length: 256 })
  comment: string;

  @ManyToOne(
    () => ForumPost,
    (forumPost) => {
      forumPost.comments;
    },
  )
  forumPost: ForumPost;
}
