import { MigrationInterface, QueryRunner } from "typeorm";

export class AddForumMembersCommentsAndPostTable1683396666542 implements MigrationInterface {
    name = 'AddForumMembersCommentsAndPostTable1683396666542'

    public async up(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`CREATE TABLE "forum_member" ("created_at" TIMESTAMP NOT NULL DEFAULT now(), "updated_at" TIMESTAMP NOT NULL DEFAULT now(), "deleted_at" TIMESTAMP, "id" uuid NOT NULL DEFAULT uuid_generate_v4(), "forum_id" character varying NOT NULL, "user_id" character varying NOT NULL, CONSTRAINT "UQ_93f3cf568fb19f2fb4ab4b61f85" UNIQUE ("forum_id"), CONSTRAINT "PK_a750489be1ea75347892d93e4b6" PRIMARY KEY ("id"))`);
        await queryRunner.query(`CREATE TABLE "forum_post" ("created_at" TIMESTAMP NOT NULL DEFAULT now(), "updated_at" TIMESTAMP NOT NULL DEFAULT now(), "deleted_at" TIMESTAMP, "id" uuid NOT NULL DEFAULT uuid_generate_v4(), "title" character varying NOT NULL, "description" character varying NOT NULL, "forum_id" character varying NOT NULL, "user_id" character varying NOT NULL, CONSTRAINT "PK_35363fad61a4ba1fb0ba562b444" PRIMARY KEY ("id"))`);
        await queryRunner.query(`CREATE TABLE "forum_post_comment" ("created_at" TIMESTAMP NOT NULL DEFAULT now(), "updated_at" TIMESTAMP NOT NULL DEFAULT now(), "deleted_at" TIMESTAMP, "id" uuid NOT NULL DEFAULT uuid_generate_v4(), "post_id" character varying NOT NULL, "user_id" character varying NOT NULL, "comment" character varying(256) NOT NULL, "forum_post_id" uuid, CONSTRAINT "PK_3074c6f2b6f87336849ea74c7b4" PRIMARY KEY ("id"))`);
        await queryRunner.query(`ALTER TABLE "forum_post_comment" ADD CONSTRAINT "FK_f523eaff5b56b43eb96286750c0" FOREIGN KEY ("forum_post_id") REFERENCES "forum_post"("id") ON DELETE NO ACTION ON UPDATE NO ACTION`);
    }

    public async down(queryRunner: QueryRunner): Promise<void> {
        await queryRunner.query(`ALTER TABLE "forum_post_comment" DROP CONSTRAINT "FK_f523eaff5b56b43eb96286750c0"`);
        await queryRunner.query(`DROP TABLE "forum_post_comment"`);
        await queryRunner.query(`DROP TABLE "forum_post"`);
        await queryRunner.query(`DROP TABLE "forum_member"`);
    }

}
