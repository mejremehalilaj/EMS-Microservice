import { ConfigService } from '@nestjs/config';
import { config } from 'dotenv';
import { DataSource, DataSourceOptions } from 'typeorm';
import { SnakeNamingStrategy } from 'typeorm-naming-strategies';

config();
const configService = new ConfigService();

export const databaseSeedsConfiguration = {
  type: 'postgres',
  ssl: configService.get('DATABASE_SSL') === 'true',
  host: configService.get('DATABASE_HOST'),
  port: configService.get('DATABASE_PORT'),
  username: configService.get('DATABASE_USERNAME'),
  password: configService.get('DATABASE_PASSWORD'),
  database: configService.get('DATABASE_NAME'),
  entities: ['dist/**/entities/*.entity.js'],
  migrations: ['dist/database/seeders/*.js'],
  autoLoadEntities: true,
  migrationsTableName: 'seeders',
  namingStrategy: new SnakeNamingStrategy(),
} as DataSourceOptions;

export default new DataSource(databaseSeedsConfiguration);
