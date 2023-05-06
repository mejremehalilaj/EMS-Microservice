import { EntityHelper } from 'src/utils/entity-helper.util';
import { Column, Entity, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class Forum extends EntityHelper {
  @PrimaryGeneratedColumn('uuid')
  id: string;

  @Column({ unique: true })
  name: string;

  @Column()
  description?: string;

  @Column()
  classId: string;
}
