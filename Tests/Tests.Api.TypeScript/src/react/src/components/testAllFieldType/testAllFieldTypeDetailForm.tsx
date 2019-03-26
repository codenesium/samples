import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypeMapper from './testAllFieldTypeMapper';
import TestAllFieldTypeViewModel from './testAllFieldTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TestAllFieldTypeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TestAllFieldTypeDetailComponentState {
  model?: TestAllFieldTypeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TestAllFieldTypeDetailComponent extends React.Component<
  TestAllFieldTypeDetailComponentProps,
  TestAllFieldTypeDetailComponentState
> {
  state = {
    model: new TestAllFieldTypeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.TestAllFieldTypeClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.TestAllFieldTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TestAllFieldTypeMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Bigint</h3>
              <p>{String(this.state.model!.fieldBigInt)}</p>
            </div>
            <div>
              <h3>Binary</h3>
              <p>{String(this.state.model!.fieldBinary)}</p>
            </div>
            <div>
              <h3>Bit</h3>
              <p>{String(this.state.model!.fieldBit)}</p>
            </div>
            <div>
              <h3>Char</h3>
              <p>{String(this.state.model!.fieldChar)}</p>
            </div>
            <div>
              <h3>Date</h3>
              <p>{String(this.state.model!.fieldDate)}</p>
            </div>
            <div>
              <h3>DateTime</h3>
              <p>{String(this.state.model!.fieldDateTime)}</p>
            </div>
            <div>
              <h3>DateTime2</h3>
              <p>{String(this.state.model!.fieldDateTime2)}</p>
            </div>
            <div>
              <h3>DateTimeOffset</h3>
              <p>{String(this.state.model!.fieldDateTimeOffset)}</p>
            </div>
            <div>
              <h3>Decimal</h3>
              <p>{String(this.state.model!.fieldDecimal)}</p>
            </div>
            <div>
              <h3>Float</h3>
              <p>{String(this.state.model!.fieldFloat)}</p>
            </div>
            <div>
              <h3>Geography</h3>
              <p>{String(this.state.model!.fieldGeography)}</p>
            </div>
            <div>
              <h3>Geometry</h3>
              <p>{String(this.state.model!.fieldGeometry)}</p>
            </div>
            <div>
              <h3>HierarchyId</h3>
              <p>{String(this.state.model!.fieldHierarchyId)}</p>
            </div>
            <div>
              <h3>Image</h3>
              <p>{String(this.state.model!.fieldImage)}</p>
            </div>
            <div>
              <h3>Money</h3>
              <p>{String(this.state.model!.fieldMoney)}</p>
            </div>
            <div>
              <h3>NChar</h3>
              <p>{String(this.state.model!.fieldNChar)}</p>
            </div>
            <div>
              <h3>NText</h3>
              <p>{String(this.state.model!.fieldNText)}</p>
            </div>
            <div>
              <h3>Numeric</h3>
              <p>{String(this.state.model!.fieldNumeric)}</p>
            </div>
            <div>
              <h3>NVarchar</h3>
              <p>{String(this.state.model!.fieldNVarchar)}</p>
            </div>
            <div>
              <h3>Real</h3>
              <p>{String(this.state.model!.fieldReal)}</p>
            </div>
            <div>
              <h3>SmallDateTime</h3>
              <p>{String(this.state.model!.fieldSmallDateTime)}</p>
            </div>
            <div>
              <h3>SmallInt</h3>
              <p>{String(this.state.model!.fieldSmallInt)}</p>
            </div>
            <div>
              <h3>SmallMoney</h3>
              <p>{String(this.state.model!.fieldSmallMoney)}</p>
            </div>
            <div>
              <h3>Text</h3>
              <p>{String(this.state.model!.fieldText)}</p>
            </div>
            <div>
              <h3>Time</h3>
              <p>{String(this.state.model!.fieldTime)}</p>
            </div>
            <div>
              <h3>Timestamp</h3>
              <p>{String(this.state.model!.fieldTimestamp)}</p>
            </div>
            <div>
              <h3>TinyInt</h3>
              <p>{String(this.state.model!.fieldTinyInt)}</p>
            </div>
            <div>
              <h3>UniqueIdentifier</h3>
              <p>{String(this.state.model!.fieldUniqueIdentifier)}</p>
            </div>
            <div>
              <h3>VarBinary</h3>
              <p>{String(this.state.model!.fieldVarBinary)}</p>
            </div>
            <div>
              <h3>Varchar</h3>
              <p>{String(this.state.model!.fieldVarchar)}</p>
            </div>
            <div>
              <h3>Variant</h3>
              <p>{String(this.state.model!.fieldVariant)}</p>
            </div>
            <div>
              <h3>XML</h3>
              <p>{String(this.state.model!.fieldXML)}</p>
            </div>
            <div>
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedTestAllFieldTypeDetailComponent = Form.create({
  name: 'TestAllFieldType Detail',
})(TestAllFieldTypeDetailComponent);


/*<Codenesium>
    <Hash>a97e0fa638e0b44a82d21d679a0e26be</Hash>
</Codenesium>*/