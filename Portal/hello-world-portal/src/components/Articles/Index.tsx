import React, { useState, useEffect } from 'react';
import { getArticles, deleteArticle } from '../../services/articleService';
import Article from '../../models/article';
import ArticleDetails from '../ArticleDetails/Index';
import { Link } from 'react-router-dom';
import Loading from '../Loading/Index';
import { TableHead, Paper, Table, TableRow, TableCell, TableBody } from '@material-ui/core';
import ArticleForm from '../ArticleForm/Index';

const deleteLine = (title: string, setUpdate: Function) => {
  deleteArticle(title)
    .then((data) => {
      setUpdate(true);
    })
    .catch((errors) => console.log(errors));
};

const updateLine = (article: Article, setUpdate: Function) => {
  setUpdate(true);
  return <ArticleForm article={article} isEdit={true}></ArticleForm>;
};

export default function Articles() {
  const [articles, setArticles] = useState<Article[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [update, setUpdate] = useState(false);

  useEffect(() => {
    setLoading(true);
    getArticles()
      .then((response) => response.json())
      .then((data: Article[]) => {
        setArticles(data);
        setLoading(false);
        console.log(data);
      })
      .catch((errors) => console.log(errors));
  }, [update]);

  if (loading) return <Loading />;

  return (
    <div>
      <h1>Articles</h1>

      <Link to="AddArticle">Add an article</Link>

      <Table size="small" aria-label="a dense table">
        <TableHead>
          <TableRow>
            <TableCell>Title</TableCell>
            <TableCell>Description</TableCell>
            <TableCell>Author</TableCell>
            <TableCell>Created on</TableCell>
            <TableCell>Tags</TableCell>
            <TableCell>Update</TableCell>
            <TableCell>Delete</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {articles.map((article) => (
            <ArticleDetails
              key={article.title}
              article={article}
              deleteLine={deleteLine}
              updateLine={updateLine}
              forceUpdate={setUpdate}
            />
          ))}
        </TableBody>
      </Table>
    </div>
  );
}
