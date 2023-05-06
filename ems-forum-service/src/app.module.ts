import { Module } from '@nestjs/common';
import { ConfigModule } from '@nestjs/config';
import { DatabaseModule } from './database/database.module';
import { ForumModule } from './forum/forum.module';

@Module({
  imports: [ConfigModule.forRoot(), DatabaseModule, ForumModule],
})
export class AppModule {}
