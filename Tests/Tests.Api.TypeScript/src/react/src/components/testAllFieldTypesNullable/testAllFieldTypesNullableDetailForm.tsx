import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypesNullableMapper from './testAllFieldTypesNullableMapper';
import TestAllFieldTypesNullableViewModel from './testAllFieldTypesNullableViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TestAllFieldTypesNullableDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface TestAllFieldTypesNullableDetailComponentState {
  model?: TestAllFieldTypesNullableViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class TestAllFieldTypesNullableDetailComponent extends React.Component<
  TestAllFieldTypesNullableDetailComponentProps,
  TestAllFieldTypesNullableDetailComponentState
> {
  state = {
    model: new TestAllFieldTypesNullableViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.TestAllFieldTypesNullables +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.TestAllFieldTypesNullableClientResponseModel;

          console.log(response);

          let mapper = new TestAllFieldTypesNullableMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
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
              <h3>FieldBigInt</h3>
              <p>{String(this.state.model!.fieldBigInt)}</p>
            </div>
            <div>
              <h3>FieldBinary</h3>
              <p>{String(this.state.model!.fieldBinary)}</p>
            </div>
            <div>
              <h3>FieldBit</h3>
              <p>{String(this.state.model!.fieldBit)}</p>
            </div>
            <div>
              <h3>FieldChar</h3>
              <p>{String(this.state.model!.fieldChar)}</p>
            </div>
            <div>
              <h3>FieldDate</h3>
              <p>{String(this.state.model!.fieldDate)}</p>
            </div>
            <div>
              <h3>FieldDateTime</h3>
              <p>{String(this.state.model!.fieldDateTime)}</p>
            </div>
            <div>
              <h3>FieldDateTime2</h3>
              <p>{String(this.state.model!.fieldDateTime2)}</p>
            </div>
            <div>
              <h3>FieldDateTimeOffset</h3>
              <p>{String(this.state.model!.fieldDateTimeOffset)}</p>
            </div>
            <div>
              <h3>FieldDecimal</h3>
              <p>{String(this.state.model!.fieldDecimal)}</p>
            </div>
            <div>
              <h3>FieldFloat</h3>
              <p>{String(this.state.model!.fieldFloat)}</p>
            </div>
            <div>
              <h3>FieldImage</h3>
              <p>{String(this.state.model!.fieldImage)}</p>
            </div>
            <div>
              <h3>FieldMoney</h3>
              <p>{String(this.state.model!.fieldMoney)}</p>
            </div>
            <div>
              <h3>FieldNChar</h3>
              <p>{String(this.state.model!.fieldNChar)}</p>
            </div>
            <div>
              <h3>FieldNText</h3>
              <p>{String(this.state.model!.fieldNText)}</p>
            </div>
            <div>
              <h3>FieldNumeric</h3>
              <p>{String(this.state.model!.fieldNumeric)}</p>
            </div>
            <div>
              <h3>FieldNVarchar</h3>
              <p>{String(this.state.model!.fieldNVarchar)}</p>
            </div>
            <div>
              <h3>FieldReal</h3>
              <p>{String(this.state.model!.fieldReal)}</p>
            </div>
            <div>
              <h3>FieldSmallDateTime</h3>
              <p>{String(this.state.model!.fieldSmallDateTime)}</p>
            </div>
            <div>
              <h3>FieldSmallInt</h3>
              <p>{String(this.state.model!.fieldSmallInt)}</p>
            </div>
            <div>
              <h3>FieldSmallMoney</h3>
              <p>{String(this.state.model!.fieldSmallMoney)}</p>
            </div>
            <div>
              <h3>FieldText</h3>
              <p>{String(this.state.model!.fieldText)}</p>
            </div>
            <div>
              <h3>FieldTime</h3>
              <p>{String(this.state.model!.fieldTime)}</p>
            </div>
            <div>
              <h3>FieldTimestamp</h3>
              <p>{String(this.state.model!.fieldTimestamp)}</p>
            </div>
            <div>
              <h3>FieldTinyInt</h3>
              <p>{String(this.state.model!.fieldTinyInt)}</p>
            </div>
            <div>
              <h3>FieldUniqueIdentifier</h3>
              <p>{String(this.state.model!.fieldUniqueIdentifier)}</p>
            </div>
            <div>
              <h3>FieldVarBinary</h3>
              <p>{String(this.state.model!.fieldVarBinary)}</p>
            </div>
            <div>
              <h3>FieldVarchar</h3>
              <p>{String(this.state.model!.fieldVarchar)}</p>
            </div>
            <div>
              <h3>FieldXML</h3>
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

export const WrappedTestAllFieldTypesNullableDetailComponent = Form.create({
  name: 'TestAllFieldTypesNullable Detail',
})(TestAllFieldTypesNullableDetailComponent);


/*<Codenesium>
    <Hash>6329733baee34f11a7e7b075db52bf9e</Hash>
</Codenesium>*/