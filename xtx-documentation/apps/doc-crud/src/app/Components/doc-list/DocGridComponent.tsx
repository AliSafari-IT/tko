import { GridComponent, ColumnsDirective, ColumnDirective, Page, ForeignKey, Inject } from '@syncfusion/ej2-react-grids';
// import { data } from './DataSource';
import { BaseComponent } from './base';
// import data from './data.json';
import './DocList.module.css';
import { GetAllDocs } from './DocDataSource'

export class DocGridComponent extends BaseComponent {
    getData() {
        return GetAllDocs();
    }
    render() {
        return (<div className='control-pane'>
            <div className='control-section'>
                <GridComponent dataSource={this.getData().props} allowPaging={true} pageSettings={{ pageCount: 4 }}>
                    <ColumnsDirective>
                        <ColumnDirective field='documentId' headerText='ID' width='50' textAlign='Center'></ColumnDirective>
                        <ColumnDirective field='docTitle' headerText='Title' width='100' textAlign="Left"></ColumnDirective>
                        <ColumnDirective field='dateCreated' headerText='Date Created' width='100' format='yMd' textAlign='Right' />
                        <ColumnDirective field='stateModelId' headerText='Edit  State' width='120' format='C2' textAlign='Right' foreignKeyField='stateModelId' />
                        <ColumnDirective field='dateModified' headerText='Date Modified' width='130' format='yMd' textAlign='Right'></ColumnDirective>
                        <ColumnDirective field='docContent' headerText='Content' width='150'></ColumnDirective>
                    </ColumnsDirective>
                    <Inject services={[Page, ForeignKey]} />
                </GridComponent>
            </div>
        </div>);
    }
};

