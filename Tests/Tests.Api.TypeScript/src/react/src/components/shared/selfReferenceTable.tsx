import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SelfReferenceMapper from '../selfReference/selfReferenceMapper';
import SelfReferenceViewModel from '../selfReference/selfReferenceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface SelfReferenceTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface SelfReferenceTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<SelfReferenceViewModel>;
}

export class  SelfReferenceTableComponent extends React.Component<
SelfReferenceTableComponentProps,
SelfReferenceTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: SelfReferenceViewModel) {
  this.props.history.push(ClientRoutes.SelfReferences + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: SelfReferenceViewModel) {
   this.props.history.push(ClientRoutes.SelfReferences + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
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
          let response = resp.data as Array<Api.SelfReferenceClientResponseModel>;

          console.log(response);

          let mapper = new SelfReferenceMapper();
          
          let selfReferences:Array<SelfReferenceViewModel> = [];

          response.forEach(x =>
          {
              selfReferences.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: selfReferences,
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
                    Header: 'SelfReferences',
                    columns: [
					  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'SelfReferenceId',
                      accessor: 'selfReferenceId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.SelfReferences + '/' + props.original.selfReferenceId); }}>
                          {String(
                            props.original.selfReferenceIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'SelfReferenceId2',
                      accessor: 'selfReferenceId2',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.SelfReferences + '/' + props.original.selfReferenceId2); }}>
                          {String(
                            props.original.selfReferenceId2Navigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SelfReferenceViewModel
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
                              row.original as SelfReferenceViewModel
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
    <Hash>f7b1b3dc49ce152713acb25ead002a90</Hash>
</Codenesium>*/