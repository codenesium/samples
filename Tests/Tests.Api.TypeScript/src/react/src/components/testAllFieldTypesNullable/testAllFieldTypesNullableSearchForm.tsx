import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TestAllFieldTypesNullableMapper from './testAllFieldTypesNullableMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from 'react-table';
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
import 'react-table/react-table.css';
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TestAllFieldTypesNullableSearchComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TestAllFieldTypesNullableSearchComponentState {
  records: Array<TestAllFieldTypesNullableViewModel>;
  filteredRecords: Array<TestAllFieldTypesNullableViewModel>;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  searchValue: string;
  deleteSubmitted: boolean;
  deleteSuccess: boolean;
  deleteResponse: string;
}

export default class TestAllFieldTypesNullableSearchComponent extends React.Component<
  TestAllFieldTypesNullableSearchComponentProps,
  TestAllFieldTypesNullableSearchComponentState
> {
  state = {
    deleteSubmitted: false,
    deleteSuccess: false,
    deleteResponse: '',
    records: new Array<TestAllFieldTypesNullableViewModel>(),
    filteredRecords: new Array<TestAllFieldTypesNullableViewModel>(),
    searchValue: '',
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.loadRecords();
  }

  handleEditClick(e: any, row: TestAllFieldTypesNullableViewModel) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: TestAllFieldTypesNullableViewModel) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/' + row.id
    );
  }

  handleCreateClick(e: any) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/create'
    );
  }

  handleDeleteClick(
    e: any,
    row: Api.TestAllFieldTypesNullableClientResponseModel
  ) {
    axios
      .delete(
        Constants.ApiEndpoint +
          ApiRoutes.TestAllFieldTypesNullables +
          '/' +
          row.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(resp => {
        this.setState({
          ...this.state,
          deleteResponse: 'Record deleted',
          deleteSuccess: true,
          deleteSubmitted: true,
        });
        this.loadRecords(this.state.searchValue);
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          ...this.state,
          deleteResponse: 'Error deleting record',
          deleteSuccess: false,
          deleteSubmitted: true,
        });
      });
  }

  handleSearchChanged(e: React.FormEvent<HTMLInputElement>) {
    this.loadRecords(e.currentTarget.value);
  }

  loadRecords(query: string = '') {
    this.setState({ ...this.state, searchValue: query });
    let searchEndpoint =
      Constants.ApiEndpoint +
      ApiRoutes.TestAllFieldTypesNullables +
      '?limit=100';

    if (query) {
      searchEndpoint += '&query=' + query;
    }

    axios
      .get<Array<Api.TestAllFieldTypesNullableClientResponseModel>>(
        searchEndpoint,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        let viewModels: Array<TestAllFieldTypesNullableViewModel> = [];
        let mapper = new TestAllFieldTypesNullableMapper();

        response.data.forEach(x => {
          viewModels.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          records: viewModels,
          filteredRecords: viewModels,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);
        this.setState({
          records: new Array<TestAllFieldTypesNullableViewModel>(),
          filteredRecords: new Array<TestAllFieldTypesNullableViewModel>(),
          loading: false,
          loaded: true,
          errorOccurred: true,
          errorMessage: 'Error from API',
        });
      });
  }

  filterGrid() {}

  render() {
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      let errorResponse: JSX.Element = <span />;

      if (this.state.deleteSubmitted) {
        if (this.state.deleteSuccess) {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="success"
              style={{ marginBottom: '25px' }}
            />
          );
        } else {
          errorResponse = (
            <Alert
              message={this.state.deleteResponse}
              type="error"
              style={{ marginBottom: '25px' }}
            />
          );
        }
      }

      return (
        <div>
          {errorResponse}
          <Row>
            <Col span={8} />
            <Col span={8}>
              <Input
                placeholder={'Search'}
                id={'search'}
                onChange={(e: any) => {
                  this.handleSearchChanged(e);
                }}
              />
            </Col>
            <Col span={8}>
              <Button
                style={{ float: 'right' }}
                type="primary"
                onClick={(e: any) => {
                  this.handleCreateClick(e);
                }}
              >
                +
              </Button>
            </Col>
          </Row>
          <br />
          <br />
          <ReactTable
            data={this.state.filteredRecords}
            columns={[
              {
                Header: 'Test All Field Types Nullable',
                columns: [
                  {
                    Header: 'Field Big Int',
                    accessor: 'fieldBigInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldBigInt)}</span>;
                    },
                  },
                  {
                    Header: 'Field Binary',
                    accessor: 'fieldBinary',
                    Cell: props => {
                      return <span>{String(props.original.fieldBinary)}</span>;
                    },
                  },
                  {
                    Header: 'Field Bit',
                    accessor: 'fieldBit',
                    Cell: props => {
                      return <span>{String(props.original.fieldBit)}</span>;
                    },
                  },
                  {
                    Header: 'Field Char',
                    accessor: 'fieldChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldChar)}</span>;
                    },
                  },
                  {
                    Header: 'Field Date',
                    accessor: 'fieldDate',
                    Cell: props => {
                      return <span>{String(props.original.fieldDate)}</span>;
                    },
                  },
                  {
                    Header: 'Field Date Time',
                    accessor: 'fieldDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Date Time2',
                    accessor: 'fieldDateTime2',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime2)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Date Time Offset',
                    accessor: 'fieldDateTimeOffset',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.fieldDateTimeOffset)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Field Decimal',
                    accessor: 'fieldDecimal',
                    Cell: props => {
                      return <span>{String(props.original.fieldDecimal)}</span>;
                    },
                  },
                  {
                    Header: 'Field Float',
                    accessor: 'fieldFloat',
                    Cell: props => {
                      return <span>{String(props.original.fieldFloat)}</span>;
                    },
                  },
                  {
                    Header: 'Field Image',
                    accessor: 'fieldImage',
                    Cell: props => {
                      return <span>{String(props.original.fieldImage)}</span>;
                    },
                  },
                  {
                    Header: 'Field Money',
                    accessor: 'fieldMoney',
                    Cell: props => {
                      return <span>{String(props.original.fieldMoney)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Char',
                    accessor: 'fieldNChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldNChar)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Text',
                    accessor: 'fieldNText',
                    Cell: props => {
                      return <span>{String(props.original.fieldNText)}</span>;
                    },
                  },
                  {
                    Header: 'Field Numeric',
                    accessor: 'fieldNumeric',
                    Cell: props => {
                      return <span>{String(props.original.fieldNumeric)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Varchar',
                    accessor: 'fieldNVarchar',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldNVarchar)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Real',
                    accessor: 'fieldReal',
                    Cell: props => {
                      return <span>{String(props.original.fieldReal)}</span>;
                    },
                  },
                  {
                    Header: 'Field Small Date Time',
                    accessor: 'fieldSmallDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Small Int',
                    accessor: 'fieldSmallInt',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallInt)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Small Money',
                    accessor: 'fieldSmallMoney',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallMoney)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Text',
                    accessor: 'fieldText',
                    Cell: props => {
                      return <span>{String(props.original.fieldText)}</span>;
                    },
                  },
                  {
                    Header: 'Field Time',
                    accessor: 'fieldTime',
                    Cell: props => {
                      return <span>{String(props.original.fieldTime)}</span>;
                    },
                  },
                  {
                    Header: 'Field Timestamp',
                    accessor: 'fieldTimestamp',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldTimestamp)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Tiny Int',
                    accessor: 'fieldTinyInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldTinyInt)}</span>;
                    },
                  },
                  {
                    Header: 'Field Unique Identifier',
                    accessor: 'fieldUniqueIdentifier',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.fieldUniqueIdentifier)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Field Var Binary',
                    accessor: 'fieldVarBinary',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldVarBinary)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Varchar',
                    accessor: 'fieldVarchar',
                    Cell: props => {
                      return <span>{String(props.original.fieldVarchar)}</span>;
                    },
                  },
                  {
                    Header: 'Field X M L',
                    accessor: 'fieldXML',
                    Cell: props => {
                      return <span>{String(props.original.fieldXML)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TestAllFieldTypesNullableViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as TestAllFieldTypesNullableViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger"
                          onClick={(e: any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as TestAllFieldTypesNullableViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
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

export const WrappedTestAllFieldTypesNullableSearchComponent = Form.create({
  name: 'TestAllFieldTypesNullable Search',
})(TestAllFieldTypesNullableSearchComponent);


/*<Codenesium>
    <Hash>c0a15bec6ad50fbb9745eb9f1ca11037</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/