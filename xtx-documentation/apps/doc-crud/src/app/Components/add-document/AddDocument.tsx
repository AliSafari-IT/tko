import React from 'react';

import { Route, Link } from 'react-router-dom';

import './AddDocument.module.css';

/* eslint-disable-next-line */
export interface AddDocumentProps {}

export function AddDocument(props: AddDocumentProps) {
  return (
    <div>
      <h1>Add New Document!</h1>

      <ul>
        <li>
          <Link to="/">AddDocument root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => <div>This is the AddDocument root route.</div>}
      />
    </div>
  );
}

export default AddDocument;
