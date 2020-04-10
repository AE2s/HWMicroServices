import Author from './author';
import Tag from './tag';

export default interface Article {
  title: string;
  description: string;
  createdOn?: Date;
  deletedOn?: Date;
  author: Author;
  tags: Tag[];
}
