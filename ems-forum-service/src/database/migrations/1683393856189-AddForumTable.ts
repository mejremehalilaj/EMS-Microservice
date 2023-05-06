import { MigrationInterface, QueryRunner } from "typeorm";

export class AddForumTable1683393856189 implements MigrationInterface {
    name = 'AddForumTable1683393856189'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`CREATE TABLE "forum" ("created_at" TIMESTAMP NOT NULL DEFAULT now(), "updated_at" TIMESTAMP NOT NULL DEFAULT now(), "deleted_at" TIMESTAMP, "id" uuid NOT NULL DEFAULT uuid_generate_v4(), "name" character varying NOT NULL, "description" character varying NOT NULL, "class_id" character varying NOT NULL, CONSTRAINT "UQ_ae78e7016c3362ec2a73ba5c615" UNIQUE ("name"), CONSTRAINT "PK_ffd925a9b1fa44ab1ce26c9821c" PRIMARY KEY ("id"))`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`DROP TABLE "forum"`);
    }

}
