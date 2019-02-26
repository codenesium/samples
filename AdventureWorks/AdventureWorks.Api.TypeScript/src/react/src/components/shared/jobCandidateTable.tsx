import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import JobCandidateMapper from '../jobCandidate/jobCandidateMapper';
import JobCandidateViewModel from '../jobCandidate/jobCandidateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface JobCandidateTableComponentProps {
  jobCandidateID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface JobCandidateTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<JobCandidateViewModel>;
}

export class  JobCandidateTableComponent extends React.Component<
JobCandidateTableComponentProps,
JobCandidateTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: JobCandidateViewModel) {
  this.props.history.push(ClientRoutes.JobCandidates + '/edit/' + row.id);
}

handleDetailClick(e:any, row: JobCandidateViewModel) {
  this.props.history.push(ClientRoutes.JobCandidates + '/' + row.id);
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
          let response = resp.data as Array<Api.JobCandidateClientResponseModel>;

          console.log(response);

          let mapper = new JobCandidateMapper();
          
          let jobCandidates:Array<JobCandidateViewModel> = [];

          response.forEach(x =>
          {
              jobCandidates.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: jobCandidates,
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
                    Header: 'JobCandidates',
                    columns: [
					  {
                      Header: 'BusinessEntityID',
                      accessor: 'businessEntityID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Employees + '/' + props.original.businessEntityID); }}>
                          {String(
                            props.original.businessEntityIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'JobCandidateID',
                      accessor: 'jobCandidateID',
                      Cell: (props) => {
                      return <span>{String(props.original.jobCandidateID)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Resume',
                      accessor: 'resume',
                      Cell: (props) => {
                      return <span>{String(props.original.resume)}</span>;
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
                              row.original as JobCandidateViewModel
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
                              row.original as JobCandidateViewModel
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
    <Hash>b4121ae4f3cff3f02f8e0b4ad4c0e11e</Hash>
</Codenesium>*/