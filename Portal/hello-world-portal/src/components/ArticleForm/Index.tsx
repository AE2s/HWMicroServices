import React, { useState } from 'react';
import { TextField, Button } from '@material-ui/core';
import SaveIcon from '@material-ui/icons/Save';
import Tag from '../../models/tag';
import Article from '../../models/article';
import { addArticle, updateArticle } from '../../services/articleService';

interface ArticleUpdate {
  article: Article;
  isEdit: boolean;
}

const actionClick = (article: Article, setmessage: Function, update: boolean) => {
  if (!update) {
    addArticle(article)
      .then((data) => {
        data.ok ? setmessage('success add') : setmessage('error');
        console.log(data);
      })
      .catch((errors) => console.log(errors));
  } else {
    updateArticle(article)
      .then((data) => {
        data.ok ? setmessage('success update') : setmessage('error');
        console.log(data);
      })
      .catch((errors) => console.log(errors));
  }

  window.location.href = '/Articles';
};

const getTags = (value: string, settags: Function): void => {
  let tagsName = value.split(',');
  const tags = tagsName.map((x) => ({ name: x }));
  settags(tags);
};

export default function ArticleForm({ ...rest }) {
  const params = rest.location.state;
  const [title, settitle] = useState(params.isEdit ? params.title : '');
  const [description, setdescription] = useState(params.isEdit ? params.description : '');
  const [lastName, setlastName] = useState(params.isEdit ? params.author.lastName : '');
  const [firstName, setfirstName] = useState(params.isEdit ? params.author.firstName : '');
  const [tags, settags] = useState<Tag[]>(params.isEdit ? params.tags : []);
  const [message, setmessage] = useState('');

  return (
    <div>
      <TextField id="standard-basic" label="Title" value={title} onChange={(e) => settitle(e.target.value)} />
      <br></br>
      <TextField
        id="standard-basic"
        label="Description"
        value={description}
        onChange={(e) => setdescription(e.target.value)}
      />
      <br></br>
      <TextField
        id="standard-basic"
        label="Author last name"
        value={lastName}
        onChange={(e) => setlastName(e.target.value)}
      />
      <br></br>
      <TextField
        id="standard-basic"
        label="Author first name"
        value={firstName}
        onChange={(e) => setfirstName(e.target.value)}
      />
      <br></br>
      <TextField
        id="standard-basic"
        label="Tags"
        value={tags.map((x) => x.name)}
        onChange={(e) => getTags(e.target.value, settags)}
      />
      <br></br>
      <br></br>
      <p>{message}</p>
      <Button
        variant="contained"
        color="primary"
        size="small"
        startIcon={<SaveIcon />}
        onClick={() =>
          actionClick({ title, description, author: { lastName, firstName }, tags }, setmessage, params.isEdit)
        }
      >
        Save
      </Button>
    </div>
  );
}
