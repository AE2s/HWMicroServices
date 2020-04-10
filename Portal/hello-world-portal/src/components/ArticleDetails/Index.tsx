import React from 'react';
import Article from '../../models/article';
import { Link } from 'react-router-dom';
import DeleteIcon from '@material-ui/icons/Delete';
import CreateIcon from '@material-ui/icons/Create';
import { IconButton, TableRow, TableCell } from '@material-ui/core';

interface ArticlesProps {
  article: Article;
  deleteLine: Function;
  updateLine: Function;
  forceUpdate: Function;
}

export default function ArticleDetails({ article, deleteLine, updateLine, forceUpdate }: ArticlesProps) {
  return (
    <TableRow>
      <TableCell>{article.title}</TableCell>
      <TableCell>{article.description}</TableCell>
      <TableCell>
        {article.author.firstName} {article.author.lastName}
      </TableCell>
      <TableCell>{article.createdOn}</TableCell>
      <TableCell>{article.tags.map((x) => x.name).join(', ')}</TableCell>
      <TableCell>
        <IconButton aria-label="update" onClick={() => updateLine(article, forceUpdate)}>
          <CreateIcon fontSize="small" />
        </IconButton>
        <Link to={{ pathname: `/UpdateArticle/${article}`, state: { ...article, isEdit: true } }}>update</Link>
      </TableCell>
      <TableCell>
        <IconButton
          aria-label="delete"
          onClick={() => {
            deleteLine(article.title, forceUpdate);
          }}
        >
          <DeleteIcon fontSize="small" />
        </IconButton>
      </TableCell>
    </TableRow>
  );
}
