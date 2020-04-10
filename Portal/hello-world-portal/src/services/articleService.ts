import configs from '../config.json';
import Article from '../models/article';

export const getArticles = async (): Promise<Response> => {
  const rootUrl = configs.services.article.url;
  const articles = await fetch(`${rootUrl}/Article/items`);
  return articles;
};

export const updateArticle = async (data: Article) => {
  const rootUrl = configs.services.article.url;
  const response = await fetch(`${rootUrl}/Article/update`, {
    method: 'PUT',
    headers: {
      Pragma: 'no-cache',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  return response;
};

export const addArticle = async (data: Article) => {
  const rootUrl = configs.services.article.url;
  const response = await fetch(`${rootUrl}/Article/add`, {
    method: 'POST',
    headers: {
      Pragma: 'no-cache',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  });

  return response;
};

export const deleteArticle = async (title: string) => {
  const rootUrl = configs.services.article.url;
  const response = await fetch(`${rootUrl}/Article/delete`, {
    method: 'DELETE',
    headers: {
      Pragma: 'no-cache',
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(title),
  });

  return response;
};
