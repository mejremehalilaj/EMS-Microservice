import { EntityHelper } from 'src/utils/entity-helper.util';
import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class ForumMember extends EntityHelper {
  @PrimaryGeneratedColumn('uuid')
  id: string;

  @Column({ unique: true })
  forumId: string;

  @Column()
  userId: string;
}
