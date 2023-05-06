import { CreateDateColumn, DeleteDateColumn, UpdateDateColumn } from 'typeorm';

export class EntityHelper {
  @CreateDateColumn()
  createdAt: Date;

  @UpdateDateColumn()
  updatedAt: Date;

  @DeleteDateColumn()
  deletedAt: Date;
}
