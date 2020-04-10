import React from 'react';
import './App.css';
import Articles from './components/Articles/Index';
import { Route, Link } from 'react-router-dom';
import ArticleForm from './components/ArticleForm/Index';
import ArticleDetails from './components/ArticleDetails/Index';

function App() {
  return (
    <div>
      <ul className="list-group">
        <li className="list-group-item">
          <Link to="/">Home</Link>
        </li>
        <li className="list-group-item">
          <Link to="/articles">Articles</Link>
        </li>
      </ul>
      <Route path="/Articles" component={Articles} />
      <Route path="/AddArticle" component={ArticleForm} />
      <Route path="/Article/:title" component={ArticleDetails} />
      <Route path="/UpdateArticle/:article" component={ArticleForm} />
    </div>
  );
}

export default App;
