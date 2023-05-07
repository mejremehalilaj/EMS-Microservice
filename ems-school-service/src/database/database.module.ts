import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { databaseConfiguration } from './database.config';

@Module({ imports: [TypeOrmModule.forRoot(databaseConfiguration)] })
export class DatabaseModule {}
