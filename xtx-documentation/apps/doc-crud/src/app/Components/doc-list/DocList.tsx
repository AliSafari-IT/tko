
import { DocGridComponent } from './DocGridComponent'
import {GetAllDocs} from '../doc-list/DocDataSource'
import './DocList.module.css';
/* eslint-disable-next-line */
export interface DocListProps {}                                                                                                                                                   



export function DocList(props: DocListProps) {

  return (
    <div>
      <h1>Document List</h1>
      <GetAllDocs />
    </div>
  );
}

export default DocList;
