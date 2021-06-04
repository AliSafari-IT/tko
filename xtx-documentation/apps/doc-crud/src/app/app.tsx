import styles from './app.module.css';

import { ReactComponent as Logo } from './logo.svg';
import star from './star.svg';

import { Route, Link } from 'react-router-dom';

import { Ui } from '@xtx-documentation/ui';
import { DocList } from './Components/doc-list/DocList';
import AddDocument from './Components/add-document/AddDocument';
import GetStarted from './Components/GetStarted/get-started';
export function App() {
  return (
    <div className={styles.app}>
      <header className="flex">
        <Logo width="75" height="75" />
        <h1>Technical Documentation System</h1>
      </header>
      <main>

        <details open>
          <summary>View Documents</summary>
          <DocList />
        </details>
        <details>
          <summary>Add Document</summary>
          <AddDocument />
        </details>
        <details>
          <summary>Get Started</summary>
        <GetStarted />
        </details>
      </main>

      {/* START: routes */}
      {/* These routes and navigation have been generated for you */}
      {/* Feel free to move and update them to fit your needs */}
      <br />
      <hr />
      <br />
      <div role="navigation">
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/ui">Ui</Link>
          </li>
          <li>
            <Link to="/page-2">Page 2</Link>
          </li>
        </ul>
      </div>
      <Route
        path="/"
        exact
        render={() => (
          <div>
            This is the generated root route.{' '}
            <Link to="/page-2">Click here for page 2.</Link>
          </div>
        )}
      />
      <Route path="/ui" component={Ui} />
      <Route
        path="/page-2"
        exact
        render={() => (
          <div>
            <Link to="/">Click here to go back to root page.</Link>
          </div>
        )}
      />
      {/* END: routes */}
    </div>
  );
}

export default App;
