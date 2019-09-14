import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from '../rate/rateMapper';
import RateViewModel from '../rate/rateViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface RateTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface RateTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<RateViewModel>;
}

export class RateTableComponent extends React.Component<
  RateTableComponentProps,
  RateTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: RateViewModel) {
    this.props.history.push(ClientRoutes.Rates + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: RateViewModel) {
    this.props.history.push(ClientRoutes.Rates + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.RateClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new RateMapper();

        let rates: Array<RateViewModel> = [];

        response.data.forEach(x => {
          rates.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: rates,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'Rates',
                columns: [
                  {
                    Header: 'Amount Per Minute',
                    accessor: 'amountPerMinute',
                    Cell: props => {
                      return (
                        <span>{String(props.original.amountPerMinute)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Teacher',
                    accessor: 'teacherId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Teachers +
                                '/' +
                                props.original.teacherId
                            );
                          }}
                        >
                          {String(
                            props.original.teacherIdNavigation &&
                              props.original.teacherIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Teacher Skill',
                    accessor: 'teacherSkillId',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.TeacherSkills +
                                '/' +
                                props.original.teacherSkillId
                            );
                          }}
                        >
                          {String(
                            props.original.teacherSkillIdNavigation &&
                              props.original.teacherSkillIdNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as RateViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as RateViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>13777af680df366ab8e18afd4aa52dc2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/