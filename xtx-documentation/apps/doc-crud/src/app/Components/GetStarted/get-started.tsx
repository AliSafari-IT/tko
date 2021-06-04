import React from 'react';

import { Route, Link } from 'react-router-dom';

import './get-started.module.css';

/* eslint-disable-next-line */
export interface GetStartedProps {}

export function GetStarted(props: GetStartedProps) {
  return (
    <div>
      <h1>Welcome to GetStarted!</h1>

      <ul>
        <li>
          <Link to="/">GetStarted root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => <div>This is the GetStarted root route.</div>}
      />
    </div>
  );
}

export default GetStarted;
