import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ColumnSameAsFKTableMapper from '../columnSameAsFKTable/columnSameAsFKTableMapper';
import ColumnSameAsFKTableViewModel from '../columnSameAsFKTable/columnSameAsFKTableViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface ColumnSameAsFKTableTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface ColumnSameAsFKTableTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<ColumnSameAsFKTableViewModel>;
}

export class  ColumnSameAsFKTableTableComponent extends React.Component<
ColumnSameAsFKTableTableComponentProps,
ColumnSameAsFKTableTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: ColumnSameAsFKTableViewModel) {
  this.props.history.push(ClientRoutes.ColumnSameAsFKTables + '/edit/' + row.id);
}

handleDetailClick(e:any, row: ColumnSameAsFKTableViewModel) {
  this.props.history.push(ClientRoutes.ColumnSameAsFKTables + '/' + row.id);
}

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.ColumnSameAsFKTableClientResponseModel>;

          console.log(response);

          let mapper = new ColumnSameAsFKTableMapper();
          
          let columnSameAsFKTables:Array<ColumnSameAsFKTableViewModel> = [];

          response.forEach(x =>
          {
              columnSameAsFKTables.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: columnSameAsFKTables,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'ColumnSameAsFKTables',
                    columns: [
					  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'Person',
                      accessor: 'person',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.People + '/' + props.original.person); }}>
                          {String(
                            props.original.personNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'PersonId',
                      accessor: 'personId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.People + '/' + props.original.personId); }}>
                          {String(
                            props.original.personIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as ColumnSameAsFKTableViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as ColumnSameAsFKTableViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>e98d57a0ac66f2396ea8ac24462d7942</Hash>
</Codenesium>*/